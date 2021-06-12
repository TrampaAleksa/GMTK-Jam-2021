using System;
using _Project.Aleksa.End;
using _Project.Aleksa.Signals;
using TMPro;

namespace _Project.Aleksa.Clock
{
    public class TimerClock : TimerSignalEvent
    {
        public TextMeshPro timerDisplay;

        private void Update()
        {
            //TODO -When the timer resets, remove the text for one second
            timerDisplay.text = ((int) SignalDisconnectedTimer.Instance.timeRemaining).ToString(); 
        }
    }
}