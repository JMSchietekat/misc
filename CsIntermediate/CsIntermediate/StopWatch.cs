using System;

namespace CsIntermediate
{
    public class StopWatch
    {
        enum StopWatchState{
            Stopped = 0,
            Running = 1
        }

        private StopWatchState _state = StopWatchState.Stopped;
        private DateTime StartDateTime { get; set; }
        private DateTime StopDateTime { get; set; }
        
        public void Start()
        {
            if (_state == StopWatchState.Running)
                throw new InvalidOperationException();

            _state = StopWatchState.Running;
            StartDateTime = DateTime.Now;
        }   
        
        public void Stop()
        {
            if (_state == StopWatchState.Stopped)
                return;
            
            _state = StopWatchState.Stopped;
            StopDateTime = DateTime.Now;
        }

        public TimeSpan Duration()
        {
            return StopDateTime - StartDateTime;
        }
    }
}