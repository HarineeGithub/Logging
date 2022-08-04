using System;
using System.ComponentModel;

namespace Logging.API
{
    public class LoggingAttribute
    {
        private string _logMessage;
        [DefaultValue("This is a test log message")]
        public string LogMessage
        {
            get
            {
                return _logMessage;
            }
            set
            {
                _logMessage = value;
            }
        }

        private string _logSeverity;
        [DefaultValue("Information")]
        public string LogSeverity
        {
            get
            {
                return _logSeverity;
            }
            set
            {
                _logSeverity = value;
            }
        }

        private string _applicationId;
        [DefaultValue("AppId1")]
        public string ApplicationId
        {
            get
            {
                return _applicationId;
            }
            set
            {
                _applicationId = value;
            }
        }

    }
}
