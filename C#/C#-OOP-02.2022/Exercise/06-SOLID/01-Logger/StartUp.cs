using _01_Logger.Appender;
using _01_Logger.Layout;
using _01_Logger.LogFiles;
using _01_Logger.Loggers;
using _01_Logger.ReportLevel;
using System;

namespace _01_Logger
{
    public class StartUp
    {
        public static void Main()
        {
            ////first part
            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender =
            //new ConsoleAppender(simpleLayout);
            //ILogger logger = new Logger(consoleAppender);

            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
            ////end first part

            ////second part
            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);

            //var file = new LogFile();
            //var fileAppender = new FileAppender(simpleLayout, file);

            //var logger = new Logger(consoleAppender, fileAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
            ////end second part

            ////third part
            //var xmlLayout = new XmlLayout();
            //var consoleAppender = new ConsoleAppender(xmlLayout);
            //var file = new LogFile();
            //var fileAppender = new FileAppender(xmlLayout,file);
            //var logger = new Logger(consoleAppender,fileAppender);

            //logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            //logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");
            ////end third part

            ////fourth part
            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = LogLevel.Error;

            //var logger = new Logger(consoleAppender);

            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");
            ////end fourth part

            ILogger logger = new Logger();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var appenderInfo = Console.ReadLine().Split();

                IAppender appender = null;

                var type = appenderInfo[0];
                var layoutType = appenderInfo[1];
                ILayout layout = null;

                if (layoutType == "SimpleLayout")
                {
                    layout = new SimpleLayout();
                }
                else if (layoutType == "XmlLayout")
                {
                    layout = new XmlLayout();
                }

                if (type == "ConsoleAppender")
                {
                    appender = new ConsoleAppender(layout);
                }
                else if (type == "FileAppender")
                {
                    ILogFile logFile = new LogFile();
                    appender = new FileAppender(layout, logFile);
                }

                if (appenderInfo.Length==3)
                {
                    var isValidLogLevel = Enum.TryParse(appenderInfo[2], true,out LogLevel logLevel);

                    if (isValidLogLevel)
                    {
                        appender.ReportLevel= logLevel;
                    }
                }

                logger.Appenders.Add(appender);
            }

            var input = string.Empty;

            while ((input=Console.ReadLine())!="END")
            {
                var messageArgs = input.Split("|");

                var logLevel = messageArgs[0];
                var date = messageArgs[1];
                var message = messageArgs[2];

                var isValidLogLevel = Enum.TryParse(logLevel, true, out LogLevel messageLogLevel);

                if (!isValidLogLevel)
                {
                    continue;
                }

                if (messageLogLevel == LogLevel.Info)
                {
                    logger.Info(date, message);
                }
                else if (messageLogLevel == LogLevel.Warning)
                {
                    logger.Warning(date, message);
                }
                else if (messageLogLevel == LogLevel.Error)
                {
                    logger.Error(date, message);
                }
                else if (messageLogLevel == LogLevel.Critical)
                {
                    logger.Critical(date, message);
                }
                else if (messageLogLevel == LogLevel.Fatal)
                {
                    logger.Fatal(date, message);
                }
            }

            Console.WriteLine("Logger info");

            Console.WriteLine(logger.GetLoggerInfo());
        }
    }
}
