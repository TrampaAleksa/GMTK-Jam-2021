using _Project.Aleksa.Clock;
using _Project.Aleksa.Sounds;
using UnityEngine;

namespace _Project.Aleksa.End
{
    public class Alarm : Timer
    {
        public static Alarm Instance;
        
        [SerializeField]
        private LevelFinish levelFinish;
        private AnimateLight _lightAnimations;

        private void Awake()
        {
            Instance = this;
            InitTimer();
            
            _lightAnimations = FindObjectOfType<AnimateLight>();
        }

        protected override void TimerEnded()
        {
            levelFinish.LoseGame();
        }

        protected override void TimerStarted()
        {
            AudioHolder.Instance.AlarmStart();
            _lightAnimations.StartAlert();
        }

        protected override void TimerCanceled()
        {
            AudioHolder.Instance.AlarmStop();
            _lightAnimations.StartNormal();
        }

        protected override void OnUpdateTimer()
        {
        }
    }
}