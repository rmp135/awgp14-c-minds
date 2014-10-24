using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMinds
{
    public class GameTime
    {
        private long _startTime;
        private long _totalTime;
        private long _deltaTime;
        private long _lastUpdate;

        public long TotalTime
        {
            get { return _totalTime; }
        }

        public long DeltaTime
        {
            get { return _deltaTime; }
        }

        public GameTime()
        {
            _startTime = DateTime.Now.Ticks;
            _deltaTime = 0;
            _totalTime = 0;
            _lastUpdate = _startTime;
        }

        public void Update()
        {
            _deltaTime = DateTime.Now.Ticks - _lastUpdate;
            _totalTime = DateTime.Now.Ticks - _startTime;
            _lastUpdate = DateTime.Now.Ticks;
        }
    }
}
