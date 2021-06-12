using System;
using UnityEngine;

public class Signal : MonoBehaviour
{
    public RaycastHit hit;
    public LineRenderer line;

    [SerializeField]
    private SignalEvent[] events;
    [SerializeField]
    public Transform character1;
    [SerializeField]
    public Transform character2;

    public bool isConnected;

    public Color interruptedColor;
    public Color regularColor;
    

    public Device sender;
    public Device receiver;
    public SignalType type;
    public float range;
    public SignalState state;

    private void Update()
    {
        var disconnected = isConnected && IsInterrupted();
        if (disconnected)
        {
            Disconnect();
        }

        var reconnected = !isConnected && !IsInterrupted();
        if (reconnected)
        {
            Connect();
        }
        
        DrawSignal();
    }

    public void Disconnect()
    {
        foreach (var eSignalEvent in events)
        {
            eSignalEvent.OnDisconnect();
        }
        Debug.Log("disconnected");
        isConnected = false;
    }

    public void Connect()
    {
        foreach (var eSignalEvent in events)
        {
            eSignalEvent.OnConnect();
        }

        Debug.Log("connected");
        isConnected = true;
    }

    public bool IsInterrupted()
    {
        var receiverPosition = character1.position;
        var broadcasterPosition = character2.position;

        return Physics.Linecast(broadcasterPosition, receiverPosition, out hit, LayerMask.GetMask("Wall"));
    }

    private void DrawSignal()
    {
        var receiverPosition = character1.position;
        var broadcasterPosition = character2.position;

        line.SetPosition(0, broadcasterPosition);
        line.SetPosition(1, receiverPosition);
    }

    public float Damperer
    {
        get
        {
            var deviceDistance = Vector3.Distance(receiver.transform.position, sender.transform.position);
            var inverseLerp = Mathf.InverseLerp(range, 0, deviceDistance);
            inverseLerp = Mathf.Clamp(inverseLerp, 0, 0.5f);
            return inverseLerp;
        }
    }
    
    public bool InRange
    {
        get => Vector3.Distance(receiver.transform.position, sender.transform.position) < range * 0.9f;
    }

    
}