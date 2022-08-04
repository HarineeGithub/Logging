using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggingController : ControllerBase
    {
        //Define Logger object
        private readonly ILogger<LoggingController> _logger;

        //Assign value to Logger object (Dependency Injection)
        public LoggingController(ILogger<LoggingController> logger)
        {
            _logger = logger;
        }

        //API to Write logs based on Log Severity
        [HttpGet]
        public string WriteLog(string logMessage = "This is a test log message", string logSeverity = "Information", string applicationId = "AppID1")
        {
            LoggingAttribute _logAttribute = new LoggingAttribute()
            {
                ApplicationId = applicationId,
                LogMessage = logMessage,
                LogSeverity = logSeverity
            };

            switch (_logAttribute.LogSeverity)
            {
                case "Information":
                    LogManager.Configuration.Variables["logfilename"] = "InformationLog"; //Define Custom LogFileName
                    _logger.LogInformation($"Log Information message: {_logAttribute.LogMessage} from the Application: {_logAttribute.ApplicationId}"); //Write Log
                    break;
                case "Error":
                    LogManager.Configuration.Variables["logfilename"] = "ErrorLog";
                    _logger.LogError($"Log Error message: {_logAttribute.LogMessage} from the Application: {_logAttribute.ApplicationId}");
                    break;
                case "Warning":
                    LogManager.Configuration.Variables["logfilename"] = "WarningLog";
                    _logger.LogWarning($"Log Warning message: {_logAttribute.LogMessage} from the Application: {_logAttribute.ApplicationId}");
                    break;
            }

            return _logAttribute.LogSeverity + " Logs written"; //API returns the LogSeverity that was written
        }

        //API to Write mutiple/bulk logs based on Log Severity
        [HttpPost]
        [Route("WriteMultipleLogs")]
        public List<string> WriteMultipleLogs(List<LoggingAttribute> _logAttributes)
        {
            List<string> _logResult = new List<string>();
            foreach (var _logAttribute in _logAttributes)
            {
                switch (_logAttribute.LogSeverity)
                {
                    case "Information":
                        LogManager.Configuration.Variables["logfilename"] = "InformationLog"; //Define Custom LogFileName
                        _logger.LogInformation($"Log Information message: {_logAttribute.LogMessage} from the Application: {_logAttribute.ApplicationId}"); //Write Log
                        break;
                    case "Error":
                        LogManager.Configuration.Variables["logfilename"] = "ErrorLog";
                        _logger.LogError($"Log Error message: {_logAttribute.LogMessage} from the Application: {_logAttribute.ApplicationId}");
                        break;
                    case "Warning":
                        LogManager.Configuration.Variables["logfilename"] = "WarningLog";
                        _logger.LogWarning($"Log Warning message: {_logAttribute.LogMessage} from the Application: {_logAttribute.ApplicationId}");
                        break;
                }
                _logResult.Add(_logAttribute.LogSeverity + " Logs written");
            }

            return _logResult; //API returns the list of logs that were written
        }
    }
}
