using System.Diagnostics;

namespace FormGameOfLife
{
    internal class HiResTimer
    {
        private Stopwatch Stopwatch { get; }
        public long ElapsedMilliseconds => Stopwatch.ElapsedMilliseconds;

        public HiResTimer()
        {
            Stopwatch = new Stopwatch();
            Stopwatch.Reset();
        }

        public void Start()
        {
            if (Stopwatch.IsRunning)
                return;
            Stopwatch.Reset();
            Stopwatch.Start();
        }

        public void Stop()
        {
            Stopwatch.Stop();
        }
    }
}
