using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using System;

namespace AngloAmerican.SDET.APITest.Helper
{
    public static class ExceptionLogger
    {
        //Methods to log exceptions in output file
        #region Fields
        private static ILog _logger;
        private static ConsoleAppender _consoleAppender;
        private static FileAppender _fileAppender;
        private static RollingFileAppender _rollingfileAppender;
        private static string _layout = "%date{dd-MMM-yyyy-HH:mm:ss} [%class] [%level] [%method] -%message%newline";
        #endregion

        #region Properties
        internal static string Layout
        {
            set => _layout = value;
        }
        #endregion

        #region Private Methods
        private static PatternLayout GetPatternLayout()
        {
            var patternLayout = new PatternLayout()
            {
                ConversionPattern = _layout
            };
            patternLayout.ActivateOptions();
            return patternLayout;
        }

        private static ConsoleAppender GetConsoleAppender()
        {
            var consoleAppender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All
            };
            consoleAppender.ActivateOptions();
            return consoleAppender;
        }
        private static FileAppender GetFileAppender()
        {
            var fileAppender = new FileAppender()
            {
                Name = "FileAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = "ExceptionFileLogger.log"
            };
            fileAppender.ActivateOptions();
            return fileAppender;
        }

        private static RollingFileAppender GetRollingFileAppender()
        {
            var rollingfileAppender = new RollingFileAppender()
            {
                Name = "Rolling File Appender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = "ExceptionLoggerRolling.log",
                MaximumFileSize = "1MB",
                MaxSizeRollBackups = 10 //ExceptionFileLogger1.log,ExceptionFileLogger2.log,.....,ExceptionFileLogger10.log
            };
            rollingfileAppender.ActivateOptions();
            return rollingfileAppender;
        }
        #endregion
        #region Public Methods
        public static ILog GetLogger(Type type)
        {
            _consoleAppender = GetConsoleAppender();
            _fileAppender = GetFileAppender();
            _rollingfileAppender = GetRollingFileAppender();
            if (_logger != null)
                return _logger;
            BasicConfigurator.Configure(_consoleAppender, _fileAppender, _rollingfileAppender);
            _logger = LogManager.GetLogger(type);
            return _logger;
        }
        #endregion
    }
}
