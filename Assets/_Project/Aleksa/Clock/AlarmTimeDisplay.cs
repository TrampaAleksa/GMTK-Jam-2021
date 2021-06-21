using System;
using _Project.Aleksa.End;
using _Project.Aleksa.Signals;
using TMPro;

namespace _Project.Aleksa.Clock
{
    public class AlarmTimeDisplay : TimerSignalEvent //todo - not a signal event
    {
        public TextMeshPro timerDisplay;

        private void Update()
        {
            timerDisplay.text = ((int) Alarm.Instance.TimeRemaining()).ToString(); 
        }
    }
}