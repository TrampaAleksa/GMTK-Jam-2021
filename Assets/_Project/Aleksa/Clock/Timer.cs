using UnityEngine;

namespace _Project.Aleksa.End
{
    public abstract class Timer : MonoBehaviour
    {
        public float totalTime;
        public float timeFactor = 2f;

        private TimedAction _timedAction;
        private bool _isStarted;

        private void Awake()
        {
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
            _timedAction.AddTickAction(OnUpdate);
        }

        public void StartTimer()
        {
            if (_isStarted) return;
            _isStarted = true;

            _timedAction.StartTimedAction(TimerEnded, totalTime * timeFactor);
        }

        public void StopTimer()
        {
            if (!_isStarted) return;
            _isStarted = false;

            _timedAction.CancelTimer();
        }

        protected abstract void TimerEnded();
        protected abstract void TimerStarted();
        protected abstract void OnUpdate();
        
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