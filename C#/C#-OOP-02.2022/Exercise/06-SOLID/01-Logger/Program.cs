using _01_Logger.Appender;
using _01_Logger.Factory;
using _01_Logger.Layout;
using _01_Logger.Loggers;
using _01_Logger.ReportLevels;
using System;
using System.Collections.Generic;

namespace _01_Logger
{
    public class Program
    {
        public static void Main()
        {
            var appenders = new List<IAppender>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");
                var reportLevel = input.Length == 3 ? Enum.Parse<ReportLevel>(input[2],true) : ReportLevel.Info;
                
                ILayout layout = LayoutFactory.CreateLayout(input[1]);

                IAppender appender = AppenderFactory.CreateAppender(input[0], layout,reportLevel);

                appenders.Add(appender);
            }

            ILogger loggers = new Logger(appenders.ToArray());


            var inputs = string.Empty;
            while ((inputs = Console.ReadLine()) != "END")
            {
                var inputArgs = inputs.Split("|");

                var reportLevel = Enum.Parse<ReportLevel>(inputArgs[0],true);
                var dateTime = inputArgs[1];
                var message = inputArgs[2];

                switch (reportLevel)
                {
                    case ReportLevel.Info:
                        loggers.Info(dateTime, message);
                        break;
                    case ReportLevel.Warning:
                        loggers.Warning(dateTime, message);
                        break;
                    case ReportLevel.Error:
                        loggers.Error(dateTime, message);
                        break;
                    case ReportLevel.Critical:
                        loggers.Critical(dateTime, message);
                        break;
                    case ReportLevel.Fatal:
                        loggers.Fatal(dateTime, message);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Logger info");

            foreach (var appender in loggers.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
