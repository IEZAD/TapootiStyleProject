namespace _0_Framework.Apllication.Logger
{
    public interface ILogger
    {
        void Debug(string message);

        void Debug(string message, params object[] Parameters);

        void Debug(Exception exception);

        void Debug(Exception exception, string message);

        void Debug(Exception exception, string message, params object[] Parameters);

        void Information(string message);

        void Information(string message, params object[] Parameters);

        void Information(Exception exception);

        void Information(Exception exception, string message);

        void Information(Exception exception, string message, params object[] Parameters);

        void Warning(string message);

        void Warning(string message, params object[] Parameters);

        void Warning(Exception exception);

        void Warning(Exception exception, string message);

        void Warning(Exception exception, string message, params object[] Parameters);

        void Error(string message);

        void Error(string message, params object[] Parameters);

        void Error(Exception exception);

        void Error(Exception exception, string message);

        void Error(Exception exception, string message, params object[] Parameters);

        void Fatal(string message);

        void Fatal(string message, params object[] Parameters);

        void Fatal(Exception exception);

        void Fatal(Exception exception, string message);

        void Fatal(Exception exception, string message, params object[] Parameters);
    }
}