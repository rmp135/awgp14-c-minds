using System;

namespace Common
{
    public class GameTime
    {
        private long _startTime;
        private long _totalTime;
        private long _deltaTime;
        private long _lastUpdate;

        public long TotalTime {
            get { return TimeSpan.FromTicks(_deltaTime).Milliseconds; }
        }

        public long DeltaTime {
            get { return TimeSpan.FromTicks(_deltaTime).Milliseconds; }
        }

        public GameTime() {
            _startTime = DateTime.Now.Ticks;
            _deltaTime = 0;
            _totalTime = 0;
            _lastUpdate = _startTime;
        }

        public void Update() {
            _deltaTime = DateTime.Now.Ticks - _lastUpdate;
            _totalTime = DateTime.Now.Ticks - _startTime;
            _lastUpdate = DateTime.Now.Ticks;
        }
    }
}