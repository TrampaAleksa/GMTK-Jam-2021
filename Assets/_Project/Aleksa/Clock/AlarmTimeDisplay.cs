using System;
using _Project.Aleksa.LevelFinish;
using _Project.Aleksa.Signals;
using TMPro;

namespace _Project.Aleksa.Clock
{
    public class AlarmTimeDisplay : AlarmSignalEvent //todo - not a signal event
    {
        public TextMeshPro timerDisplay;

        private void Update()
        {
            timerDisplay.text = ((int) Alarm.Instance.TimeRemaining()).ToString(); 
        }
    }
}