using TMPro;
using UnityEngine;

namespace _Project.Aleksa.Alarm
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
            if (alarm.IsActive())
                timerDisplay.text = ((int)alarm.TimeRemaining()).ToString();
            else
                timerDisplay.text = "";
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