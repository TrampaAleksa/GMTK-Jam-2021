using _Project.Aleksa.Clock;
using _Project.Aleksa.Sounds;
using UnityEngine;

namespace _Project.Aleksa.End
{
    public class SignalDisconnectedTimer : Timer //TODO -Alarm rename
    {
        public static SignalDisconnectedTimer Instance;
        
        [SerializeField]
        private LevelFinish levelFinish;
        private AnimateLight _lightAnimations;

        private void Awake()
        {
            Instance = this;
            InitTimer();
            
            _lightAnimations = FindObjectOfType<AnimateLight>();
            levelFinish = levelFinish == null ? gameObject.AddComponent<LevelFinish>() : levelFinish;
            levelFinish.Init();
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