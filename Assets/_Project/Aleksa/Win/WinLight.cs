namespace _Project.Aleksa.Win
{
    public class WinLight : WinEvent
    {
        private AnimateLight _animateLight;

        private void Awake()
        {
            _animateLight = FindObjectOfType<AnimateLight>();
        }

        public override void Win()
        {
            base.Win();
            _animateLight.StartWin();
        }
    }
}