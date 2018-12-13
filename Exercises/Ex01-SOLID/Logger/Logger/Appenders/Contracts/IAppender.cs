namespace Solid.Logger.Appenders.Contracts
{
    using Loggers.Enums;
    public interface IAppender
    {
        int MessageCount { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, ReportLevel errorLevel, string message);
    }
}
