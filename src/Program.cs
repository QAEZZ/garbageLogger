using garbageLogger.Logger;

namespace garbageLogger;

class Program
{
    public static void Main()
    {
        Log Logger = new Log("logs", "Program.cs.log");

        Logger.Write("Information message", LogLevel.INFO);
        Logger.Write("Task message", LogLevel.TASK);
        Logger.Write("Warn message", LogLevel.WARN);
        Logger.Write("Error message", LogLevel.ERROR);
        Logger.Write("Success message", LogLevel.SUCCESS);
    }
}