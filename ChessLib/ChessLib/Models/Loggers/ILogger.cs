namespace ChessLib.Models.Loggers
{
    /// <summary>
    /// Interface provides functionality to use logging methods
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log method
        /// </summary>
        /// <param name="message">Input message to log</param>
        public void Log(string message);
    }
}
