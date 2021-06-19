using _Project.Aleksa.Sounds;
using UnityEngine;

namespace _Project.Aleksa.End
{
    /// <summary>
    /// Contains lists of events that relate to different situations that finish the current level.
    /// For eg. winning the level, losing the game via timer, or finishing the last level.
    /// </summary>
    public class LevelFinish
    {
        private AnimateLight _lightAnimator;
        private GameObject _canvas;

        public LevelFinish(AnimateLight lightAnimator)
        {
            _lightAnimator = lightAnimator;
            _canvas = GameObject.Find("LoseCanvas");
            _canvas.SetActive(false);
        }

        public void LoseGame()
        {
            Debug.Log("You lost");

            AudioHolder.Instance.PowerShutdown();
            _lightAnimator.StartLose();

            _lightAnimator.gameObject.AddComponent<TimedAction>().StartTimedAction(ActivateCanvas, 1.8f);
        }

        private void ActivateCanvas()
        {
            _canvas.SetActive(true);
        }
    }
}