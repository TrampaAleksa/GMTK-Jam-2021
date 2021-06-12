using _Project.Aleksa.End;

namespace _Project.Aleksa.Signals
{
    public class TimerSignalEvent : SignalEvent
    {
        public override void OnConnect()
        {
            base.OnConnect();
            SignalDisconnectedTimer.Instance.StopTimer();
        }

        public override void OnDisconnect()
        {
            base.OnDisconnect();
            SignalDisconnectedTimer.Instance.StartTimer();
        }
    }
}