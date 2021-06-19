using _Project.Aleksa.Sounds;

namespace _Project.Aleksa.End
{
    public class SignalDisconnectedTimer : Timer 
    {
        public static SignalDisconnectedTimer Instance;

        private LevelFinish _levelFinish;
        private AnimateLight _lightAnimations;

        private void Awake()
        {
            Instance = this;
            InitTimer();
            _levelFinish = new LevelFinish(FindObjectOfType<AnimateLight>());
            _lightAnimations = FindObjectOfType<AnimateLight>();
        }

        protected override void TimerEnded()
        {
            _levelFinish.LoseGame();
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