using UnityEngine;

public class DeviceState
{
    protected Device device;

    public DeviceState(Device device)
    {
        this.device = device;
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