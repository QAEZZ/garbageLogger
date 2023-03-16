# garbageLogger

[![License](https://img.shields.io/badge/license-WTFPL-blue.svg)](LICENSE)

## Description
I fr have no idea wtf im doing.

This project is a shit C# logger that supports five different logging levels: INFO, TASK, WARN, ERROR, and SUCCESS. The logger writes messages to the console and to a file specified by the user.

Made by [Yendy](https://github.com/YendisFish) and I for our [DAWN](https://github.com/The-Holy-Church-of-Terry-Davis/DAWN) project.

## Usage
```csharp
using garbageLogger.Logger;

Log Logger = new Log("logs", "Program.cs.log");

Logger.Write("Information message", LogLevel.INFO);
Logger.Write("Task message", LogLevel.TASK);
Logger.Write("Warn message", LogLevel.WARN);
Logger.Write("Error message", LogLevel.ERROR);
Logger.Write("Success message", LogLevel.SUCCESS);
```

![Example Image](example.png)

## Conclusion
uhhh, check out the aforementioned [DAWN](https://github.com/The-Holy-Church-of-Terry-Davis/DAWN) project.