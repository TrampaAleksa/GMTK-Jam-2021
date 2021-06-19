using UnityEngine;

namespace _Project.Aleksa.Clock
{
    public abstract class Timer : MonoBehaviour
    {
        public float totalTime;
        public float timeFactor = 2f;

        private TimedAction _timedAction;
        private bool _isStarted;

        protected void InitTimer()
        {
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
            _timedAction.AddTickAction(OnUpdateTimer);
        }

        public void StartTimer()
        {
            if (_isStarted) return;
            _isStarted = true;

            TimerStarted();
            _timedAction.StartTimedAction(TimerEnded, totalTime * timeFactor);
        }

        public void StopTimer()
        {
            if (!_isStarted) return;
            _isStarted = false;

            
            TimerCanceled();
            _timedAction.CancelTimer();
        }

        protected abstract void TimerEnded();
        protected abstract void TimerStarted();
        protected abstract void TimerCanceled();
        protected abstract void OnUpdateTimer();
        
        /// <summary>
        /// Get the time remaining divided by the time factor given
        /// (a time factor of 2 gives half the time remaining).
        /// If the timer isn't started, return the total time
        /// </summary>
        public float TimeRemaining()
        {
            if (_isStarted)
                return _timedAction.TimeRemaining / timeFactor;

            return totalTime;
        }
    }
}