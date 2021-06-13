using UnityEngine;

namespace _Project.Aleksa.End
{
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

            AudioHolder.Instance.PowerDown.Play();
            AudioHolder.Instance.AlarmStop();
            _lightAnimator.StartLose();

            _lightAnimator.gameObject.AddComponent<TimedAction>().StartTimedAction(ActivateCanvas, 1.8f);
        }

        private void ActivateCanvas()
        {
            _canvas.SetActive(true);
        }
    }
}