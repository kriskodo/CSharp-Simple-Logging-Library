using System;
using System.Collections.Generic;
using SOLID.Appenders;
using SOLID.Contracts;
using SOLID.Enums;
using SOLID.Layouts;
using SOLID.Loggers;

namespace SOLID
{
    internal static class Program
    {
        private static void Main()
        {
            var n = int.Parse(Console.ReadLine() ?? string.Empty);
            var counter = 0;
            var appenders = new List<IAppender>();

            while (counter < n)
            {
                var appenderData = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (appenderData == null) throw new Exception("Incorrect input");
                var type = appenderData[0];
                var layoutType = appenderData[1];
                string reportLevel = null;

                if (appenderData.Length >= 3)
                {
                    reportLevel = appenderData[2];
                }

                ILayout currentLayout = layoutType switch
                {
                    "SimpleLayout" => new SimpleLayout(),
                    "XmlLayout" => new XMLLayout(),
                    _ => throw new NullReferenceException("A layout type must be provided.")
                };
                

                IAppender currentAppender = type switch
                {
                    "ConsoleAppender" => new ConsoleAppender(currentLayout, GetReportLevel(reportLevel)),
                    "FileAppender" => new FileAppender(currentLayout, GetReportLevel(reportLevel)),
                    _ => throw new NullReferenceException("An appender type must be provided.")
                };

                appenders.Add(currentAppender);
                counter++;
            }


            var logger = new Logger(appenders);

            var messageInput = Console.ReadLine()?.Split("|", StringSplitOptions.RemoveEmptyEntries);

            if (messageInput?[0] is null or "") throw new Exception("Incorrect message input");

            while (messageInput[0] != "END")
            {
                var messageReportLevel = messageInput[0];
                var messageDate = messageInput[1];
                var messageContent = messageInput[2];

                LogMessage(logger, messageReportLevel, messageDate, messageContent);

                messageInput = Console.ReadLine()?.Split("|", StringSplitOptions.RemoveEmptyEntries);

                if (messageInput?[0] is null or "") throw new Exception("Incorrect message input");
            }

            appenders
                .ForEach(a =>
                    Console.WriteLine(
                        $"Appender type: {a.GetType()}, Layout type: {a.Layout.GetType()}," +
                        $"Report Level: {a.ReportLevel}, Messages appended: {a.Messages.Count}"
                    )
                );
        }

        /// <summary>
        /// Find a way to avoid switch statement.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="messageReportLevel"></param>
        /// <param name="messageDate"></param>
        /// <param name="messageContent"></param>
        private static void LogMessage(
            ILogger logger,
            string messageReportLevel,
            string messageDate,
            string messageContent)
        {
            switch (messageReportLevel.ToUpper())
            {
                case "INFO":
                    logger.Info(messageDate, messageContent);
                    break;
                case "WARNING":
                    logger.Warning(messageDate, messageContent);
                    break;
                case "ERROR":
                    logger.Error(messageDate, messageContent);
                    break;
                case "CRITICAL":
                    logger.Critical(messageDate, messageContent);
                    break;
                case "FATAL":
                    logger.Fatal(messageDate, messageContent);
                    break;
            }
        }

        /// <summary>
        /// Returns ReportLevel.Info by default[All messages are logged]
        /// </summary>
        /// <param name="reportLevel"></param>
        /// <returns>ReportLevel</returns>
        private static ReportLevel GetReportLevel(string reportLevel)
        {
            return reportLevel?.ToUpper() switch
            {
                "INFO" => ReportLevel.Info,
                "WARNING" => ReportLevel.Warning,
                "ERROR" => ReportLevel.Error,
                "CRITICAL" => ReportLevel.Critical,
                "FATAL" => ReportLevel.Fatal,
                _ => ReportLevel.Info
            };
        }
    }
}