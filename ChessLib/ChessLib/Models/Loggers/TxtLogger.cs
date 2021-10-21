using System;
using System.IO;

namespace ChessLib.Models.Loggers
{
    /// <summary>
    /// Class realize logging in text file
    /// </summary>
    public sealed class TxtLogger : ILogger
    {
        private const string FILE_EXTENSION = ".txt";
        private string _currentDirectory;
        private string _currentFile;
        private string _filename;
        private string _filepath;

        /// <summary>
        /// Text logger constructor
        /// </summary>
        public TxtLogger()
        {
            _currentDirectory = Directory.GetCurrentDirectory() + "/Logs";
            if (!Directory.Exists(_currentDirectory))
                Directory.CreateDirectory(_currentDirectory);

            int i = 0;
            _filename = "chesslog";
            _currentFile = _filename + i + FILE_EXTENSION;
            _filepath = _currentDirectory + "/" + _currentFile;
            while (File.Exists(_filepath))
            {
                i++;
                _currentFile = _filename + i + FILE_EXTENSION;
                _filepath = _currentDirectory + "/" + _currentFile;
            }
        }

        /// <summary>
        /// Logging input message in text file
        /// </summary>
        /// <param name="message">Input message</param>
        public void Log(string message)
        {
            using (StreamWriter sw = File.AppendText(_filepath))
            {
                sw.WriteLine(String.Format("{0, -65} || {1}", message, DateTime.Now));
            }
        }
    }
}
