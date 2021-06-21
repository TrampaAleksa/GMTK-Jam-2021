using _Project.Aleksa.LevelFinish;

namespace _Project.Aleksa.Signals
{
    public class TimerSignalEvent : SignalEvent
    {
        public override void OnConnect(Signal signal)
        {
            base.OnConnect(signal);
            Alarm.Instance.StopTimer();
        }

        public override void OnDisconnect(Signal signal)
        {
            base.OnDisconnect(signal);
            Alarm.Instance.StartTimer();
        }
    }
}