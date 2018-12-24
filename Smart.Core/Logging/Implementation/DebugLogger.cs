

using System;

namespace Smart.Core
{
    public class DebugLogger : ILogger
    {
        /// <summary>
        /// Logs the given message to the debug console
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="level">The level of the message</param>
        public void Log(string message, LogLevel level)
        {
           
            //Color console based on level 
            switch (level)
            {
                //Debug
                case LogLevel.Debug:
                    message = $"[debug]: {message}";
                    break;

                //Verbose
                case LogLevel.Verbose:
                    message = $"[verbose]: {message}";
                    break;

                //Informative
                case LogLevel.Informative:
                    message = $"[informative]: {message}";
                    break;

                //Warning
                case LogLevel.Warning:
                    message = $"[warning]: {message}";
                    break;

                //Error
                case LogLevel.Error:
                    message = $"[error]: {message}";
                    break;

                //Success
                case LogLevel.Success:
                    message = $"[success]: {message}";
                    break;


            }
            
            //Write message to console
            Console.WriteLine(message);

            
        }
    }
}
