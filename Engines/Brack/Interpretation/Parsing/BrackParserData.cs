using System.Collections.Generic;
using System.Text;

namespace Lockethot.Engines.Brack
{
    public class BrackParserData
    {
        private Stack<BracketType> _OpenedBrackets;
        private Stack<int> _OpenedBracketLines;
        private Stack<int> _OpenedBracketPositions;
        public BracketType LastOpenBracketType { get { return (_OpenedBrackets.Count > 0) ? _OpenedBrackets.Peek() : BracketType.NA; } }
        public int LastOpenBracketPosition { get { return (_OpenedBracketPositions.Count > 0) ? _OpenedBracketPositions.Peek() : -1; } }
        public int LastOpenBracketLine { get { return (_OpenedBracketLines.Count > 0) ? _OpenedBracketLines.Peek() : -1; } }
        public bool HasUnclosed { get { return _OpenedBrackets.Count > 0; } }
        public int LastQuoteLine = -1;
        public int LastQuotePosition = -1;
        public int LastHashLine = -1;
        public int LastHashPosition = -1;
        public string Path;
        public int Line = 0;
        public int Position = 0;
        public int Depth = 0;
        public bool InString = false;
        public bool InComment = false;
        public StringBuilder Token = new StringBuilder();
        public List<object> CurrentStatement = new List<object>();

        public BrackParserData(string path)
        {
            Path = path;
            _OpenedBrackets = new Stack<BracketType>();
            _OpenedBracketLines = new Stack<int>();
            _OpenedBracketPositions = new Stack<int>();
        }

        public void OpenBracket(BracketType type, int line, int position)
        {
            _OpenedBrackets.Push(type);
            _OpenedBracketLines.Push(line);
            _OpenedBracketPositions.Push(position);
        }

        public void CloseBracket()
        {
            _OpenedBrackets.Pop();
            _OpenedBracketLines.Pop();
            _OpenedBracketPositions.Pop();
        }

        public List<object> NewStatement()
        {
            var old = CurrentStatement;
            CurrentStatement = new List<object>();
            return old;
        }
    }
}
