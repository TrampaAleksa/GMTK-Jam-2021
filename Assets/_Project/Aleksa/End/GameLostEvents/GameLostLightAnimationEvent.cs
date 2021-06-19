using System;
using UnityEngine;

namespace _Project.Aleksa.End
{
    public class GameLostLightAnimationEvent : GameLostLevelFinishEvent
    {
        [SerializeField] private AnimateLight lightAnimator;

        private void Awake()
        {
            lightAnimator = FindObjectOfType<AnimateLight>(); // Todo - Remove find object of type
        }

        public override void FinishLevel()
        {
            lightAnimator.StartLose();
        }
    }
}