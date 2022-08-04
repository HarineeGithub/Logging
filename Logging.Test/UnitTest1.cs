using System;
using Xunit;
using Logging.API;
using Logging.API.Controllers;
using Moq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Logging.Test
{
    public class UnitTest1
    {
        //Define private read-only variables
        private readonly LoggingController _LoggingController;
        private readonly Mock<ILogger<LoggingController>> _mockLogger;

        //Initializing the private read-only variables in constructor
        public UnitTest1()
        {
            _mockLogger = new Mock<ILogger<LoggingController>>();
            _LoggingController = new LoggingController(_mockLogger.Object);
        }

        //UT for logging Information Log
        [Fact]
        public void InformationLogTest()
        {

            // Arrange
            string logMessage = "Log message from UnitTest";
            string logSeverity = "Information";
            string applicationId = "UTAppID1";

            // Act
            var result = _LoggingController.WriteLog(logMessage, logSeverity, applicationId);

            // Assert
            _mockLogger.Verify(x => x.LogInformation("Log message from UnitTest"));
            Assert.Contains("Information Logs written", result);
        }

        //UT for logging Error Log
        [Fact]
        public void ErrorLogTest()
        {

            // Arrange
            string logMessage = "Log message from UnitTest";
            string logSeverity = "Error";
            string applicationId = "UTAppID1";

            // Act
            var result = _LoggingController.WriteLog(logMessage, logSeverity, applicationId);

            // Assert
            _mockLogger.Verify(x => x.LogInformation("Log message from UnitTest"));
            Assert.Contains("Error Logs written", result);
        }

        //UT for logging Multiple Logs (bulk logging)
        [Fact]
        public void BulkLogTest()
        {

            // Arrange
            List<LoggingAttribute> _logAttributes = new List<LoggingAttribute>()
            {
                new LoggingAttribute()
                {
                    LogMessage = "Log message from UnitTest",
                    LogSeverity = "Error",
                    ApplicationId = "UTAppID1"
                },
                new LoggingAttribute()
                {
                    LogMessage = "Log message from UnitTest",
                    LogSeverity = "Information",
                    ApplicationId = "UTAppID1"
                }
            };

            // Act
            var result = _LoggingController.WriteMultipleLogs(_logAttributes);

            // Assert
            _mockLogger.Verify(x => x.LogInformation("Log message from UnitTest"));
            Assert.Collection(result,
                item => Assert.Contains("Error Logs written", item),
                item => Assert.Contains("Information Logs written", item)
            );
        }
    }
}
