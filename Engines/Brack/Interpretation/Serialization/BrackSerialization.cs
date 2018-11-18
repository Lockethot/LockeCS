using Lockethot.Collections.Extensions;
using System;
using System.IO;

namespace Lockethot.Engines.Brack
{
    public static class BrackSerialization
    {
        public static void Write(string path, string source, object[][] statements)
        {
            Write(path, new BrackFile() { Source = source, BrackStatements = statements });
        }


        public static void Write(string path, BrackFile file)
        {
            if (file == null) throw new ArgumentNullException("file");
            if (path == null) throw new ArgumentNullException("path");
            File.WriteAllBytes(path, file.ToByteArray());
        }

        public static BrackFile Read(string path)
        {
            if (path == null) throw new ArgumentNullException("path");
            try
            {
                return File.ReadAllBytes(path).ToObject<BrackFile>();
            }
            catch (FileNotFoundException)
            {
                throw new BrackFileNotFoundException(path);
            }
            catch(Exception)
            {
                throw new BrackInvalidBytesException(path);
            }
        }

        public static object[][] ReadBrack(string path)
        {
            return Read(path).BrackStatements;
        }

        public static string ReadSource(string path)
        {
            return Read(path).Source;
        }
    }
}
