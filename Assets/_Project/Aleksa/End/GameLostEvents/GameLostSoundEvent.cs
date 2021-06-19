using _Project.Aleksa.Sounds;

namespace _Project.Aleksa.End
{
    public class GameLostSoundEvent : GameLostLevelFinishEvent
    {
        public override void FinishLevel()
        {
            AudioHolder.Instance.PowerShutdown();
        }
    }
}