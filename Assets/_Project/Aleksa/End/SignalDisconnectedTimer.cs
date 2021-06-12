using UnityEngine;

namespace _Project.Aleksa.End
{
    public class SignalDisconnectedTimer : MonoBehaviour
    {
        public static SignalDisconnectedTimer Instance;
        
        public float totalTime;
        
        private TimedAction _timedAction;

        private bool isStarted;

        private void Awake()
        {
            Instance = this;
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
        }

        public void StartTimer()
        {
            if (isStarted) return;
            
            isStarted = true;
            
            _timedAction.StartTimedAction(TimerEnded, totalTime);
        }

        public void StopTimer()
        {
            if (!isStarted) return;
            
            isStarted = false;
            
            _timedAction.CancelTimer();
        }

        private void TimerEnded()
        {
            new LevelFinish().LoseGame();
        }
    }
}