public class DeviceSilent : DeviceState
{
    public DeviceSilent(Device device) : base(device)
    {
    }

    public override void Entry()
    {
        base.Entry();
        foreach (var signal in device.signals)
        {
            signal.isConnected = false;
            signal.line.endWidth = 0f;
            signal.line.startWidth = 0f;
        }
    }
    public override void UpdateAction()
    {
        base.UpdateAction();
        if (device.HasConnections())
        {
            Exit();
        }
    }
    public override void Exit()
    {
        base.Exit();
        device.state = new DeviceBroadcasting(device);
        device.state.Entry();
    }
}