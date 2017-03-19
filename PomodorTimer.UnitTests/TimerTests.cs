using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PomodoroTimero.UnitTests
{
    [TestClass]
    public class TimerTests
    {
        [TestMethod]
        public void TestValidTimes()
        {
            TimeSpan valid1 = TimeSpan.FromSeconds(0);
            TimeSpan valid2 = TimeSpan.FromSeconds(1);
            TimeSpan valid3 = TimeSpan.FromSeconds(2);
            TimeSpan valid4 = TimeSpan.FromSeconds(10);
            TimeSpan valid5 = TimeSpan.FromSeconds(59);
            TimeSpan valid6 = TimeSpan.FromMinutes(1);
            TimeSpan valid7 = TimeSpan.FromMinutes(60);
            TimeSpan valid8 = TimeSpan.FromHours(2.5);
        }
    }
}