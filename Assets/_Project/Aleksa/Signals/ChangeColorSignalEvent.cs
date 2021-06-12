namespace _Project.Aleksa.Signals
{
    public class ChangeColorSignalEvent : SignalEvent
    {
        
        public override void OnConnect(Signal signal)
        {
            base.OnConnect(signal);
            signal.line.startColor = signal.regularColor;
            signal.line.endColor= signal.regularColor;
        }

        public override void OnDisconnect(Signal signal)
        {
            base.OnDisconnect(signal);
            signal.line.startColor = signal.interruptedColor;
            signal.line.endColor= signal.interruptedColor;
        }
    }
}