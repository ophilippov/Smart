
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Smart.Core
{
    /// <summary>
    /// The standard log factory for <see cref="Smart"/>
    /// Logs details to the Debug, Console, Trace and log files
    /// </summary>
    public class BaseLogFactory : ILogFactory
    {
        #region Protected Members

        /// <summary>
        /// The list of loggers in this factory
        /// </summary>
        protected List<ILogger> mLoggers = new List<ILogger>();

        /// <summary>
        /// A lock fo the logger list to keep it threadsafe
        /// </summary>
        protected object mLoggersLock = new object();
        #endregion

        #region Public Events

        /// <summary>
        /// Fires whenever a new log arrives
        /// </summary>
        public event Action<(string Message, LogLevel Level)> NewLog = (details) => { };
        #endregion

        #region Public Properties 

        /// <summary>
        /// The level of logging to output
        /// </summary> 
        public LogOutputLevel LogOutputLevel { get; set; } = LogOutputLevel.Informative;  

        /// <summary>
        /// If true, includes the origin of where the log message was logged from,
        /// such as class name, file name, line number
        /// </summary>
        public bool IncludeLogOriginDetails { get; set; } = true;

        #endregion
        
        #region Methods


        /// <summary>
        /// Adds a specific logger to this factory 
        /// </summary>
        /// <param name="logger">The logger</param>
        public void AddLoger(ILogger logger)
        {
            //Log the list so it is thread-safe
            lock (mLoggersLock)
            {
                //If the logger is not already in the list
                if (!mLoggers.Contains(logger))
                    //Add the logger to the list
                    mLoggers.Add(logger);

            }
        }

        /// <summary>
        /// Logs the specific message to all loggers int this factory
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="level">A level of the message being logged </param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filename that this messgae was logged from</param>
        /// <param name="lineNumber">The line of code in the filename this message was logged from</param>
        public void Log(string message,
            LogLevel level = LogLevel.Informative,
            [CallerMemberName] string origin = "",
            [CallerFilePath]string filePath = "",
            [CallerLineNumber]int lineNumber = 0)
        {
            //If we should not log the message as the level is too low
            if ((int)level < (int)LogOutputLevel)
                return;


            //If the user wants to know where the log originated from..
            if (IncludeLogOriginDetails)
                
                message = $"[{Path.GetFileName(filePath)}] > {origin}() > Line {lineNumber}] {Environment.NewLine}{message}";
            //Log to all loggers
            mLoggers.ForEach(logger => logger.Log(message, level));

            //Inform listeners
            NewLog.Invoke((message, level));
        }

        /// <summary>
        /// Removes the specified logger from this factory
        /// </summary>
        /// <param name="logger">The logger</param>
        public void RemoveLoger(ILogger logger)
        {
            //Log the list so it is thread-safe
            lock (mLoggersLock)
            {
                //If the logger is already in the list
                if (mLoggers.Contains(logger))
                    //Remove the logger to the list
                    mLoggers.Remove(logger);

            } 
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseLogFactory()
        {
            //Add debug console logger
            AddLoger(new DebugLogger());

            
        }

        #endregion
    }
}
