using UnityEngine;

namespace _Project.Aleksa.End
{
    public class LevelFinish
    {
        private AnimateLight _lightAnimator;

        public LevelFinish(AnimateLight lightAnimator)
        {
            _lightAnimator = lightAnimator;
        }

        public void LoseGame()
        {
            Debug.Log("You lost");

            AudioHolder.Instance.PowerDown.Play();
            AudioHolder.Instance.AlarmStop();
            _lightAnimator.StartLose();
        }
    }
}