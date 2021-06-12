using UnityEngine;

namespace _Project.Aleksa.Win
{
    public class DebugWinEvent : WinEvent
    {
        public override void Win()
        {
            base.Win();
            Debug.Log("Won the game");
        }
    }
}