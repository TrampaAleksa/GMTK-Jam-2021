using System;
using UnityEngine;

public class SignalLineHolder : MonoBehaviour
{
    public LineRenderer redLine;
    public LineRenderer greenLine;


    public static SignalLineHolder Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public LineRenderer InitLine(Signal signal)
    {
        if (signal.type == SignalType.Bad)
        {
            return Instantiate(redLine, transform);
        }

        return Instantiate(greenLine, transform);
    }
}