using UnityEngine;

namespace _Project.Aleksa.End
{
    public class GameLostLightAnimationEvent : GameLostLevelFinishEvent
    {
        [SerializeField] private AnimateLight lightAnimator;

        public override void Finish()
        {
            lightAnimator.StartLose();
        }
    }
}