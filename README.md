# Logging
Logging.API
============
This is the .Net core Web API project

LoggingController.cs
----------------------
This is the API controller that contains 2 APIs
a. WriteLog - to write single log
b. WriteMultipleLogs - to write multiple logs. Defined custom routes.

Log File names and paths are dynamically specified.

LoggingAttribute.cs
---------------------
Model that contains the properties with get/set and default value

Logging Method:
----------------
Used NLog for logging. Refer nlog.config
Current targets are 
a. Log to File
b. Log to console (commented - can be uncommented)
c. Log to Kafka (commented - to add correct servers and uncomment to use)

nlog.config
-------------
Contains the logging targets and rules

Logging.Test
==============
This is xUnit Unit test project
Contains tests for both the APIs
