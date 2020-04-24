using System;
using System.IO;
using System.Text;

namespace LoggerDLL
{
    public interface ILogger
    {
        TException NewException<TException>(string message)
            where TException : Exception, new();

        void WriteInLog(LogType logType, string message);
    }

    public enum LogType { Info, Warning, Error }

    public class Logger : ILogger
    {

        private static string currentPath = AppDomain.CurrentDomain.BaseDirectory;

        public void WriteInLog(LogType logType, string message)
        {
            WriteMessageInLogNowDate(logType, message);
        }

        private void WriteMessageInLogNowDate(LogType logType, string message)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(currentPath + "\\Log");
            if (!dirInfo.Exists)
                dirInfo.Create();
            string type = LogType.Info == logType ? "INFO" : (LogType.Error == logType ? "ERROR" : "WARNING");
            StreamWriter f = new StreamWriter(currentPath + "\\Log\\" + String.Format("{0}.log", DateTime.Now.ToString("yyyy-MM-dd")), true, Encoding.UTF8);
            f.WriteLine($"{DateTime.Now.ToShortTimeString()} | {type} | {message}");
            f.Flush();
            f.Close();
        }

        public TException NewException<TException>(string message) where TException : Exception, new()
        {
            WriteInLog(LogType.Error, message);
            TException exc = new TException();
            return exc;
        }
    }
}
