using garbageLogger.Decorators;

namespace garbageLogger.Logger;


public class Log
{
    public string DirName { get; set; }
    public string FileName { get; set; }
    public string PathName { get; set; }


    /// <summary>
    /// The Log type...
    /// </summary>
    /// <param name="dname">The directory you want the log file to go to. Use an empty space for the current dir</param>
    /// <param name="fname">The name of the log file</param>
    /// <param name="overwrite">If you want the log file to be blank on each run of the program.</param>
    /// </summary>    
    public Log(string dname, string fname, bool overwrite = true)
    {
        DirName = dname;
        FileName = fname;
        PathName = $"{DirName}/{FileName}";

        Directory.CreateDirectory("./" + dname);
        File.Create("./" + Path.Join(dname, fname)).Close();

        if(overwrite) 
        {
            File.WriteAllText(PathName, $"[{DateTime.UtcNow} UTC] : [?] START OF LOG FOR {FileName}\n");
        }
    }

    /// <summary>
    /// Writes the message to the console and to the file specified when initializing the logger.
    /// </summary>
    /// <param name="message">The message...</param>
    /// <param name="logLevel">INFO, TASK, WARN, ERROR, and SUCCESS</param>
    public void Write(string message, LogLevel logLevel = LogLevel.INFO)
    {
        string tick = "\u2713";

        switch (logLevel) {
            case LogLevel.INFO:
                message = $"[?] {message}";
                Console.WriteLine($"{Colors.setColor(ConsoleColor.Blue)}{message}");
                break;
            case LogLevel.TASK:
                message = $"[-] {message}";
                Console.WriteLine($"{Colors.setColor(ConsoleColor.Cyan)}{message}");
                break;
            case LogLevel.WARN:
                message = $"[!] {message}";
                Console.WriteLine($"{Colors.setColor(ConsoleColor.Yellow)}{message}");
                break;
            case LogLevel.ERROR:
                message = $"[X] {message}";
                Console.WriteLine($"{Colors.setColor(ConsoleColor.Red)}{message}");
                break;
            case LogLevel.SUCCESS:
                message = $"[{tick}] {message}";
                Console.WriteLine($"{Colors.setColor(ConsoleColor.Green)}{message}");
                break;
            default:
                Console.WriteLine($"{Colors.setColor(ConsoleColor.Magenta)}{message}");
                break;
        }
        Console.ForegroundColor = ConsoleColor.White;
        DateTime now = DateTime.UtcNow;
        File.AppendAllText(PathName, $"[{now.ToString()} UTC] : {message}\n");
    }
}

/// <summary>
/// Provides logging functionality with five different logging levels: INFO, TASK, WARN, ERROR, and SUCCESS.
/// </summary>
public enum LogLevel
{
    /// <summary>
    /// Prints: <font color="blue">[?] message here</font>
    /// </summary>
    INFO,

    /// <summary>
    /// Prints: <font color="cyan">[-] message here</font>
    /// </summary>
    TASK,

    /// <summary>
    /// Prints: <font color="yellow">[!] message here</font>
    /// </summary>
    WARN,

    /// <summary>
    /// Prints: <font color="red">[X] message here</font>
    /// </summary>
    ERROR,

    /// <summary>
    /// Prints: <font color="green">[✓] message here</font>
    /// </summary>
    SUCCESS
}