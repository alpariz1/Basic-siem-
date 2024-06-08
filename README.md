# Security information and management system
Simple SIEM Program
This is a simple Security Information and Event Management (SIEM) program that reads an event log file (events.txt), detects keywords related to various events, generates alarms based on these keywords, and logs the alarms to a file (alarmlogs.txt). The program is designed to be easily extendable and can be used as a basic template for more advanced SIEM systems.

Features
Reads event logs from a specified file.
Detects predefined keywords in the event logs.
Generates alarms for specific keywords.
Logs the generated alarms to a persistent file.
Adds a timestamp at the start of each run for easy log segmentation.
Prerequisites
.NET SDK  (7.0)
 
