public class SignalState
{
    public bool IsConnected { get => signal.isConnected && !signal.IsInterrupted() && signal.InRange;}
    public Signal signal;

    public SignalState(Signal signal)
    {
        this.signal = signal;
    }

    public virtual void Entry()
    {
        
    }
    public virtual void UpdateAction()
    {
        
    }
    public virtual void Exit()
    {
        
    }
    
    
}