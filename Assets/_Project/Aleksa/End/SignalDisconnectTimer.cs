using UnityEngine;

namespace _Project.Aleksa.End
{
    public class SignalDisconnectTimer : MonoBehaviour
    {
        public float totalTime;
        private TimedAction timedAction;

        public TimerEndedEvent[] events;

        private void Awake()
        {
            timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
            events = GetComponentsInChildren<TimerEndedEvent>();
        }

        public void StartTimer()
        {
            timedAction.StartTimedAction(TimerEnded, totalTime);
        }

        public void StopTimer()
        {
            timedAction.CancelTimer();
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