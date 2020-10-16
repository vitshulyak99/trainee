using System;
using System.IO;
using Task4.Provider.Interface;

namespace Task4.Provider
{
    public class TextProvider : ITextIO
    {
        private string _path = "";
        object locker = new object();
        public DateTime LastModified
        {
            get
            {
                lock (locker) return File.GetLastWriteTime(_path);
            }
        }

        public TextProvider(string path)
        {
            _path = path;
        }

        public string ReadAll()
        {
            lock (locker)
                using (StreamReader reader = new StreamReader(_path))
                {
                    return reader.ReadToEnd();
                }
        }

        public void Write(char sym, bool append)
        {
            lock (locker)
                using (StreamWriter writer = new StreamWriter(_path, append))
                {
                    writer.Write(sym);
                }
        }


    }
}
