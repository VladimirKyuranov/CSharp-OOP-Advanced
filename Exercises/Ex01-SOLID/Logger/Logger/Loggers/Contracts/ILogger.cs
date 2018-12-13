﻿namespace Solid.Logger.Loggers.Contracts
{
    public interface ILogger
    {
        void Error(string dateTime, string errorMessage);

        void Info(string dateTime, string errorMessage);
    }
}
