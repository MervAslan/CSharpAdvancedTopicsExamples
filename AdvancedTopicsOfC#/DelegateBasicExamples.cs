
using System;
using System.IO;


namespace Delegates
{
    class DelegateBasicExamples
    {
        delegate void LogDel(string text); 
        static void Main(string[] args)
        {
            log log = new log(); 

            LogDel LogTextToScreenDel, LogTextToFileDel; // defined 2 delegate variable

            LogTextToScreenDel = new LogDel(log.LogTextToScreen); // assign method to delegate variable also you can write without using new keyword--> log.LogTextToScreen

            LogTextToFileDel = new LogDel(log.LogTextToFile);      // assign method to delegate variable

            LogDel multiLogDel = LogTextToScreenDel + LogTextToFileDel;     // multicast delegate

            Console.WriteLine("Enter your name:");

            var name = Console.ReadLine();

            LogText(multiLogDel, name);

            Console.ReadKey();
        }
        static void LogText(LogDel logDel, string text) // delegate can be used as parameter
        {
            logDel(text);
        }

    }

    public class log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}:{text}");
        }
        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}:{text}");
            }
        }
    }
}
