namespace _Project.Aleksa.End
{
    public class GameOverTimer : TimerEndedEvent
    {
        public override void End()
        {
            base.End();
            new LevelFinish().LoseGame();
        }
    }
}