using _Project.Aleksa.LevelFinish;
using UnityEngine;

namespace _Project.Aleksa.Signals
{
    public class AlarmSignalEvent : SignalEvent
    {
        private Alarm.Alarm _alarm;

        private void Awake()
        {
            _alarm = GetAlarm();
        }

        public override void OnConnect(Signal signal)
        {
            base.OnConnect(signal);
            //_alarm.StopTimer();
        }

        public override void OnDisconnect(Signal signal)
        {
            base.OnDisconnect(signal);
            _alarm.StartTimer();
        }


        private Alarm.Alarm GetAlarm()
        {
            var alarm = FindObjectOfType<Alarm.Alarm>();
            
            if (alarm == null)
            {
                Debug.LogWarning("No alarm component found, returning default implementation", this);

                alarm = gameObject.AddComponent<Alarm.Alarm>();
                alarm.totalTime = 99;
                alarm.timeFactor = 1f;
            }
            
            return alarm;
        }
    }
}