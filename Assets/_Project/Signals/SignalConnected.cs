public class SignalConnected : SignalState
{
    public SignalConnected(Signal signal) : base(signal)
    {
    }

    public override void Entry()
    {
        base.Entry();
        signal.Connect();
    }

    public override void UpdateAction()
    {
        base.UpdateAction();

        if (!IsConnected)
        {
            Exit();
            return;
        }

        var width = signal.Damperer;
        signal.line.endWidth = width;
        signal.line.startWidth = width;

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
        signal.state = new SignalDisconnected(signal);
        signal.state.Entry();
    }
}