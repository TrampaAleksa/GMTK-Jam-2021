using UnityEngine;

namespace _Project.Aleksa.End
{
    public class SignalDisconnectTimer : MonoBehaviour
    {
        public static SignalDisconnectTimer Instance;
        
        public float totalTime;
        public TimerEndedEvent[] events;
        
        private TimedAction _timedAction;

        private void Awake()
        {
            Instance = this;
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
            events = GetComponentsInChildren<TimerEndedEvent>();
        }

        public void StartTimer()
        {
            _timedAction.StartTimedAction(TimerEnded, totalTime);
        }

        public void StopTimer()
        {
            _timedAction.CancelTimer();
        }

        private void TimerEnded()
        {
            foreach (var timerEndedEvent in events)
            {
                timerEndedEvent.End();
            }
        }
    }
}