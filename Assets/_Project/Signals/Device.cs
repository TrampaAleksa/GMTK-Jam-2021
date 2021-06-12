using System;
using System.Collections.Generic;
using UnityEngine;

public class Device : MonoBehaviour
{
    public int connections;

    [SerializeField] private List<SignalConnection> sendingTo;
    [NonSerialized] public List<Signal> signals;
    [NonSerialized] public DeviceState state;

    public SFinalDevice FinalDevice;

    private void Awake()
    {
        if (CompareTag("FinalDevice"))
        {
            FinalDevice = GetComponent<SFinalDevice>();
        }
        
        signals = new List<Signal>();

        foreach (var connection in sendingTo)
        {
            var signal = new Signal();
            
            signal.receiver = connection.device;
            signal.sender = this;
            signal.type = connection.type;
            signal.line = FindObjectOfType<SignalLineHolder>().InitLine(signal);
            signal.state = new SignalDisconnected(signal);
            signal.range = connection.range;
            signals.Add(signal);
        }
        
        state = new DeviceSilent(this);
    }

    private void Update()
    {
        state.UpdateAction();
        
        foreach (var signal in signals)
        {
            signal.state.UpdateAction();
        }
    }

    public bool HasConnections() => connections > 0;
}

[Serializable]
public class SignalConnection
{
    [SerializeField] public Device device;
    [SerializeField] public SignalType type;
    [SerializeField] public float range;
}

public enum SignalType
{
    Bad,
    Good,
}