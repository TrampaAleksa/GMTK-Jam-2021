using _Project.Aleksa.Sounds;

namespace _Project.Aleksa.Win
{
    public class WinSound : WinEvent
    {
        public override void Win()
        {
            base.Win();
            AudioHolder.Instance.PowerRestore();
        }
    }
}