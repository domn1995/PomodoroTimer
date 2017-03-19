using System;
using System.Collections.Generic;
using System.Timers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timer = PomodoroTimer.Library.Timer;

namespace PomodoroTimer.UnitTests
{
    [TestClass]
    public class TimerTests
    {
        [TestMethod]
        public void TestSettingValidTimeRemainings()
        {
            List<TimeSpan> validTimes = new List<TimeSpan>()
            {
                TimeSpan.FromMilliseconds(1000),
                TimeSpan.FromSeconds(0.0),
                TimeSpan.FromSeconds(0.000001),
                TimeSpan.FromSeconds(0),
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(59),
                TimeSpan.FromMinutes(1),
                TimeSpan.FromMinutes(1.5),
                TimeSpan.FromMinutes(5.1),
                TimeSpan.FromMinutes(60),
                TimeSpan.FromHours(2.5),
            };

            Timer t = new Timer();

            foreach (TimeSpan validTime in validTimes)
            {
                t.TimeRemaining = validTime;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSettingInvalidTimeRemainings()
        {
            List<TimeSpan> invalidTimes = new List<TimeSpan>()
            {
                TimeSpan.FromSeconds(0.5),
                TimeSpan.FromSeconds(1.01),
                TimeSpan.FromSeconds(-1),
                TimeSpan.FromMilliseconds(769),
                TimeSpan.FromTicks(123456789),
                TimeSpan.FromMinutes(1.23),
                TimeSpan.FromHours(1.111),
            };

            Timer t = new Timer();

            foreach (TimeSpan invalidTime in invalidTimes)
            {
                t.TimeRemaining = invalidTime;
                Assert.Fail();
            }
        }
    }
}