using System;
using System.IO;

namespace ChessLib.Models.Loggers
{
    public class TxtLogger : ILogger
    {
        private const string FILE_EXTENSION = ".txt";
        private string _currentDirectory;
        private string _currentFile;
        private string _filename;
        private string _filepath;

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

        public void Log(string message)
        {
            using (StreamWriter sw = File.AppendText(_filepath))
            {
                sw.WriteLine(message + " |||| " + DateTime.Now);
            }
        }
    }
}
