using System;
using System.Threading;
using System.Threading.Tasks;

namespace PomodoroTimer.Library
{
    public delegate void TimerTick(object sender, TimeSpan timeLeft);

    /// <summary>
    /// Responsible for managing time.
    /// </summary>
    public class Timer
    {
        private const long ticksPerSecond = 10000000;
        private TimeSpan timeRemaining;
        private readonly CancellationTokenSource cts = new CancellationTokenSource();
        public bool IsRunning { get; private set; }
        public event TimerTick Tick;

        public TimeSpan TimeRemaining
        {
            get
            {
                return timeRemaining;
            }
            set
            {
                if (value.TotalSeconds < 0)
                {
                    throw new ArgumentException($"Time remaining must be zero or more seconds.");
                }

                if (value.Ticks % TimeSpan.TicksPerSecond != 0)
                {
                    throw new ArgumentException($"Time remaining seconds must not be fractional.");
                }

                timeRemaining = value;
            }
        }

        public void Start()
        {
            IsRunning = true;
            while (timeRemaining.TotalSeconds > 0)
            {
                Tick?.Invoke(this, timeRemaining);
                timeRemaining = timeRemaining.Subtract(TimeSpan.FromSeconds(1));
                Task.Delay(1000).Wait();
            }
            Tick?.Invoke(this, timeRemaining);
        }

        public async void StartAsync()
        {
            await Task.Factory.StartNew(Start, cts.Token);
        }

        public void Stop()
        {
            cts.Cancel();
            IsRunning = false;
        }

        public void Reset()
        {
            Stop();
            timeRemaining = TimeSpan.FromSeconds(0);
        }
    }
}