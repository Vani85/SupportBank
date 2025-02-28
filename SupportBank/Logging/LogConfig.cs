using NLog;
using NLog.Config;
using NLog.Targets;

namespace Logging {
    public class LogConfig{

        public static void ConfigureLog() {
            var config = new LoggingConfiguration();
            var logPath = Directory.GetCurrentDirectory();
            var target = new FileTarget { FileName = @logPath+"\\Logging\\Logs\\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;
        }    
    }
}        