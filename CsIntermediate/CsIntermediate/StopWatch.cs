using System;

namespace CsIntermediate
{
    public class StopWatch
    {

        private bool _running;
        private DateTime _startDateTime;
        private DateTime _stopDateTime;
        
        public void Start()
        {
            if (_running)
                throw new InvalidOperationException();

            _running = true;
            _startDateTime = DateTime.Now;
        }   
        
        public void Stop()
        {
            if (!_running)
                return;

            _running = false;
            _stopDateTime = DateTime.Now;
        }

        public TimeSpan Duration() => _stopDateTime - _startDateTime;
    }
}