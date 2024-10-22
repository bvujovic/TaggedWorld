using System;

namespace WinAppTaggedWorld.Classes
{
    public class StopWatch
    {
        private DateTime start;

        public TimeSpan Interval => interval;
        private TimeSpan interval;

        public StopWatch() { Start(); }

        public void Start() { start = DateTime.Now; }

        public void Stop() { interval = DateTime.Now - start; }

        public override string ToString()
        {
            Stop();
            return interval.ToString("s\\.fff");
        }
    }
}
