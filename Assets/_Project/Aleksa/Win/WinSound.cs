namespace _Project.Aleksa.Win
{
    public class WinSound : WinEvent
    {
        public override void Win()
        {
            base.Win();
            AudioHolder.Instance.PowerRestored.Play();
            AudioHolder.Instance.Alarm.Stop();
        }
    }
}