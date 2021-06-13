using UnityEngine;

namespace _Project.Aleksa.End
{
    public class SignalDisconnectedTimer : MonoBehaviour
    {
        public static SignalDisconnectedTimer Instance;
        
        public float totalTime;
        public float timeFactor = 2f;
        
        [HideInInspector]
        public float timeRemaining;

        private TimedAction _timedAction;

        private bool isStarted;

        private void Awake()
        {
            Instance = this;

            timeRemaining = totalTime;
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
            _timedAction.AddTickAction(UpdateRemainingTime);
        }

        public void StartTimer()
        {
            if (isStarted) return;
            
            isStarted = true;

            AudioHolder.Instance.AlarmStart();
            
            _timedAction.StartTimedAction(TimerEnded, totalTime*timeFactor);
        }

        public void StopTimer()
        {
            if (!isStarted) return;
            
            isStarted = false;
            
            AudioHolder.Instance.AlarmStop();
            
            timeRemaining = totalTime;
            _timedAction.CancelTimer();
        }

        private void TimerEnded()
        {
            new LevelFinish().LoseGame();
        }

        private void UpdateRemainingTime() => timeRemaining -= Time.deltaTime/timeFactor;
    }
}