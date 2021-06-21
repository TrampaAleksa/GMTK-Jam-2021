using _Project.Aleksa.Clock;
using _Project.Aleksa.LevelFinish.Lose;
using _Project.Aleksa.Sounds;
using UnityEngine;

namespace _Project.Aleksa.LevelFinish
{
    public class Alarm : Timer
    {
        public static Alarm Instance;

        private IGameLost _levelLostEvent;
        private AnimateLight _lightAnimations;

        private void Awake()
        {
            Instance = this;
            InitTimer();

            _levelLostEvent = GetLevelLostEvent();
            _lightAnimations = GetLightAnimations();
        }

        protected override void TimerStarted()
        {
            AudioHolder.Instance.AlarmStart();
            _lightAnimations.StartAlert();
        }

        protected override void OnUpdateTimer()
        {
        }

        protected override void TimerCanceled()
        {
            AudioHolder.Instance.AlarmStop();
            _lightAnimations.StartNormal();
        }

        protected override void TimerEnded()
        {
            _levelLostEvent.LoseGame();
        }


        private IGameLost GetLevelLostEvent()
        {
            var levelLostEvent = GetComponentInChildren<IGameLost>();
            
            if (levelLostEvent == null)
            {
                Debug.LogWarning("No lost level event component found, returning null implementation", this);
                levelLostEvent = gameObject.AddComponent<NullLevelLostEvent>();
            }

            return levelLostEvent;
        }

        private AnimateLight GetLightAnimations()
        {
            var lightAnimations = FindObjectOfType<AnimateLight>();
            
            if (lightAnimations == null)
            {
                Debug.LogWarning("No lost light animator component found, returning null implementation", this);
                lightAnimations = gameObject.AddComponent<AnimateLight>();
            }

            return lightAnimations;
        }
    }
}