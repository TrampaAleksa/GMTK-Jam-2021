using System;
using _Project.Aleksa.Sounds;
using UnityEngine;

namespace _Project.Aleksa.End
{
    public class SignalDisconnectedTimer : MonoBehaviour //TODO - Extract Timer class
    {
        public static SignalDisconnectedTimer Instance;
        
        public float totalTime;
        public float timeFactor = 2f;

        private TimedAction _timedAction;

        private bool isStarted;

        private LevelFinish _levelFinish;

        private AnimateLight _lightAnimations;

        private void Awake()
        {
            Instance = this;
            _timedAction = gameObject.AddComponent<TimedAction>().DestroyOnFinish(false);
            _levelFinish = new LevelFinish(FindObjectOfType<AnimateLight>());
            _lightAnimations = FindObjectOfType<AnimateLight>();
        }

        public void StartTimer()
        {
            if (isStarted) return;
            
            isStarted = true;

            AudioHolder.Instance.AlarmStart();
            _lightAnimations.StartAlert();
            
            _timedAction.StartTimedAction(TimerEnded, totalTime*timeFactor);
        }

        public void StopTimer()
        {
            if (!isStarted) return;
            
            isStarted = false;
            
            AudioHolder.Instance.AlarmStop();
            _lightAnimations.StartNormal();
            
            _timedAction.CancelTimer();
        }

        private void TimerEnded()
        {
            _levelFinish.LoseGame();
        }

        public float TimeRemaining
        {
            get
            {
                if (isStarted)
                    return _timedAction.TimeRemaining / timeFactor;

                return totalTime;
            }
        }
    }
}