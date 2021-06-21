using System;
using _Project.Aleksa.LevelFinish;
using _Project.Aleksa.Signals;
using TMPro;
using UnityEngine;

namespace _Project.Aleksa.Clock
{
    public class AlarmTimeDisplay : MonoBehaviour
    {
        public TextMeshPro timerDisplay;
        [SerializeField]
        private Alarm alarm;

        private void Awake()
        {
            alarm = GetAlarm();
        }

        private void Update()
        {
            timerDisplay.text = ((int) alarm.TimeRemaining()).ToString();
        }

        
        
        
        private Alarm GetAlarm()
        {
            if (alarm != null)
                return alarm;

            alarm = FindObjectOfType<Alarm>();

            if (alarm != null)
                return alarm;

            Debug.LogWarning("No alarm component found, returning default implementation", this);

            alarm = gameObject.AddComponent<Alarm>();
            alarm.totalTime = 99;
            alarm.timeFactor = 1f;

            return alarm;
        }
    }
}