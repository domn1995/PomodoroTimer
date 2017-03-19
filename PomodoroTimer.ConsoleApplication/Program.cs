using System;
using PomodoroTimer.Library;

namespace PomodoroTimer.ConsoleApplication
{
    public static class Program
    {
        public static void Main()
        {
            Timer t = new Timer();
            t.TimeRemaining = TimeSpan.FromSeconds(5);
            t.Tick += OnTimerTick;
            t.StartAsync();
            Console.WriteLine("Execution is not being blocked!");
            Console.ReadLine();
        }

        private static void OnTimerTick(object o, TimeSpan ts)
        {
            Console.WriteLine(ts);
        }
    }
}