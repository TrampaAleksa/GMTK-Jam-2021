public class SignalDisconnected : SignalState
{
    public SignalDisconnected(Signal signal) : base(signal)
    {
    }

    public override void Entry()
    {
        base.Entry();
        signal.Disconnect();
    }

    public override void UpdateAction()
    {
        base.UpdateAction();
        if (IsConnected)
        {
            Exit();
        }

        if (!signal.InRange)
        {
            signal.line.endWidth = 0;
            signal.line.startWidth = 0;
        }
        
        if (signal.IsInterrupted())
        {
            SignalLineDrawer.WallLineDraw(signal);
            return;
        }
        SignalLineDrawer.ReceiverLineDraw(signal);

    }

    public override void Exit()
    {
        base.Exit();
        signal.state = new SignalConnected(signal);
        signal.state.Entry();
    }
}