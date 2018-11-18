using Lockethot.Design.Behavioral.InterpreterPattern;
using System.Collections.Generic;
using System.IO;
namespace Lockethot.Engines.Brack
{
    public class BrackParser : StringArrayInterpreter<object, BrackParserData>
    {
        #region Public Overridable Methods
        public override void InterpretChar(string raw, int index, ref BrackParserData data, List<object> result)
        {
            var escaped = false;
            var curC = raw[index];
            var befC = (index-1 >= 0) ? raw[index - 1] : ' ';
            if (curC == '\n')
            {
                data.Position = 0;
                data.Line++;
            }
            else
            {
                data.Position++;
            }
            if (curC != '\\' || IsOddForwardSlash(raw, index))
            {
                if (befC == '\\')
                {
                    if (IsEscapeCharacter(curC))
                    {
                        escaped = true;
                        curC = ConvertEscapeCharacter(curC);
                    }
                    else
                    {
                        throw new BrackInvalidEscapeException(ProjectPath + "//" + data.Path, data.Line, data.Position);
                    }
                }
                if (!data.InComment)
                {
                    if (!data.InString)
                    {
                        if (!escaped && curC == '#')
                        {
                            data.InComment = true;
                            data.LastHashLine = data.Line;
                            data.LastHashPosition = data.Position;
                        }
                        else if (data.Depth == 0)
                        {
                            if (!escaped && IsOpenBracket(curC))
                            {
                                data.Depth = 1;
                                data.OpenBracket(CharToBracketType(curC), data.Line, data.Position);
                            }
                        }
                        else if (data.Depth == 1)
                        {
                            if (string.IsNullOrWhiteSpace(curC.ToString()))
                            {
                                if (data.Token.Length != 0)
                                {
                                    data.CurrentStatement.Add(ParseStringObj(data.Token.ToString()));
                                    data.Token.Clear();
                                }
                            }
                            else if(!escaped)
                            {
                                if (curC == '\"')
                                {
                                    if (data.Token.Length != 0)
                                    {
                                        data.CurrentStatement.Add(ParseStringObj(data.Token.ToString()));
                                        data.Token.Clear();
                                    }
                                    data.InString = true;
                                    data.LastQuoteLine = data.Line;
                                    data.LastQuotePosition = data.Position;
                                }
                                else if (IsOpenBracket(curC))
                                {
                                    if (data.Token.Length != 0)
                                    {
                                        data.CurrentStatement.Add(ParseStringObj(data.Token.ToString()));
                                        data.Token.Clear();
                                    }
                                    data.Depth = 2;
                                }
                                else if (IsClosedBracket(curC))
                                {
                                    if (data.Token.Length != 0)
                                    {
                                        data.CurrentStatement.Add(ParseStringObj(data.Token.ToString()));
                                        data.Token.Clear();
                                    }
                                    result.Add(data.NewStatement());
                                    data.Depth = 0;
                                    var type = CharToBracketType(curC);
                                    if (data.LastOpenBracketType != type)
                                    {
                                        throw new BrackNotMatchingBracketException(data.LastOpenBracketType, type, ProjectPath + "//" + data.Path, data.Line, data.Position);
                                    }
                                    data.CloseBracket();
                                }
                                else
                                {
                                    data.Token.Append(curC);
                                }
                            }
                            else
                            {
                                data.Token.Append(curC);
                            }
                        }
                    }
                    else if (data.Depth > 1)
                    {
                        if (!escaped)
                        {
                            if (IsClosedBracket(curC))
                            {
                                data.Depth--;   
                            }
                            if (IsOpenBracket(curC))
                            {
                                data.Depth++;
                            }
                        }
                        data.Token.Append(curC);
                        if (data.Depth == 1)
                        {
                            data.CurrentStatement.Add(InterpretStringRecursive(data.LastOpenBracketLine, data.LastOpenBracketPosition, data.Path,data.Token.ToString())[0]); //RECURSIVE CALL
                        }
                    }
                    else //if (data.InString)
                    {
                        if (!escaped && curC == '\"')
                        {
                            data.InString = false;
                            if (data.Depth == 1)
                            {
                                data.CurrentStatement.Add(ParseStringObj(data.Token.ToString()));
                                data.Token.Clear();
                            }
                        }
                        else
                        {
                            data.Token.Append(curC);
                        }
                    }
                }
                else //if (data.inComment)
                {
                    if (!escaped && curC == '#')
                    {
                        data.InComment = false;
                    }
                }
            }
        }

        public override object[] Interperet(string path)
        {
            var dat = new BrackParserData(path);
            var ret = InterpretLoop(File.ReadAllText(path), dat);
            if (dat.InComment)
            {
                throw new BrackUnclosedHashException(ProjectPath + "//" + path, dat.LastHashLine, dat.LastHashPosition);
            }
            else if (dat.InString)
            {
                throw new BrackUnclosedQuoteException(ProjectPath + "//" + path, dat.LastQuoteLine, dat.LastQuotePosition);
            }
            else if (dat.HasUnclosed)
            {
                throw new BrackUnclosedBracketException(dat.LastOpenBracketType, ProjectPath + "//" + path, dat.LastOpenBracketLine, dat.LastOpenBracketPosition);
            }
            return ret;
        }

        private object[] InterpretStringRecursive(int line, int position, string path, string raw)
        {
            var dat = new BrackParserData(path)
            {
                Line = line,
                Position = position
            };
            var ret = InterpretLoop(raw, dat);
            return ret;
        }
        #endregion

        public static bool IsOpenBracket(char c)
        {
            return c == '[' || c == '(' || c == '{' || c == '<';
        }

        public static bool IsClosedBracket(char c)
        {
            return c == ']' || c == ')' || c == '}' || c == '>';
        }

        public static object ParseStringObj(string raw)
        {
            if (float.TryParse(raw, out float fnum))
            {
                return fnum;
            }
            return raw;
        }

        public static bool IsEscapeCharacter(char c)
        {
            return c == '\'' || c == '\"' || c == '\\' || c == 'a' || c == 'b' || c == 'f' || c == 'n' || c == 'r' || c == 't' || c == 'v' || c == '#' || c == '[' || c == ']' || c == '(' || c == ')' || c == '{' || c == '}' || c == '<' || c == '>';
        }

        public static char ConvertEscapeCharacter(char c)
        {
            switch(c)
            {
                case 'a':
                    return '\a';
                case 'b':
                    return '\b';
                case 'f':
                    return '\f';
                case 'n':
                    return '\n';
                case 'r':
                    return '\r';
                case 'v':
                    return '\v';
                default:
                    return c;
            }
        }

        public static BracketType CharToBracketType(char c)
        {
            switch(c)
            {
                case '[':
                case ']':
                    return BracketType.Square;
                case '(':
                case ')':
                    return BracketType.Parenthesis;
                case '{':
                case '}':
                    return BracketType.Squigley;
                case '<':
                case '>':
                    return BracketType.Carrot;
                default:
                    return BracketType.NA;
            }
        }

        private static bool IsOddForwardSlash(string raw, int index)
        {
            bool isOdd = false;
            while(raw[--index] == '\\')
            {
                isOdd = !isOdd;
            }
            return isOdd;
        }

        public string ProjectPath;
    }
}
