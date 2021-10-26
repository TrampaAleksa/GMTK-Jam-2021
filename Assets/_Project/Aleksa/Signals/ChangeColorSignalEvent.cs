namespace _Project.Aleksa.Signals
{
    public class ChangeColorSignalEvent : SignalEvent
    {
        
        public override void OnConnect(Signal signal)
        {
            base.OnConnect(signal);
            signal.ChangeSignalColor(signal.regularColor);
        }

        public override void OnDisconnect(Signal signal)
        {
            base.OnDisconnect(signal);
            signal.ChangeSignalColor(signal.interruptedColor);
        }
    }
}