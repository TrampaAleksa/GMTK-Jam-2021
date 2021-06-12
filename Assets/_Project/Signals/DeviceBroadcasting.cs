using UnityEngine;

public class DeviceBroadcasting : DeviceState
{
    public DeviceBroadcasting(Device device) : base(device)
    {
    }

    public override void Entry()
    {
        base.Entry();
        foreach (var signal in device.signals)
        {
            signal.isConnected = true;
            // signal.line.endWidth = 0.04f;
            // signal.line.startWidth = 0.04f;
        }
    }

    public override void UpdateAction()
    {
        base.UpdateAction();
        if (device.HasConnections())
        {
            return;
        }
        Exit();

    }

    public override void Exit()
    {
        base.Exit();
        device.state = new DeviceSilent(device);
        device.state.Entry();
    }
}