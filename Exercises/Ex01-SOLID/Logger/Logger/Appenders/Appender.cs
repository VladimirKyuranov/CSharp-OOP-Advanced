namespace Solid.Logger.Appenders
{
    using Contracts;
    using Layouts.Contracts;
    using Loggers.Enums;

    public abstract class Appender : IAppender
    {
        private readonly ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        protected ILayout Layout => this.layout;

        public ReportLevel ReportLevel { get; set; }

        public int MessageCount { get; protected set; }

        public abstract void Append(string dateTime, ReportLevel errorLevel, string message);
    }
}
