using _Project.Aleksa.End;

namespace _Project.Aleksa.Signals
{
    public class TimerSignalEvent : SignalEvent
    {
        public override void OnConnect(Signal signal)
        {
            base.OnConnect(signal);
            SignalDisconnectedTimer.Instance.StopTimer();
        }

        public override void OnDisconnect(Signal signal)
        {
            base.OnDisconnect(signal);
            SignalDisconnectedTimer.Instance.StartTimer();
        }
    }
}