using _Project.Aleksa.Sounds;
using UnityEngine;

namespace _Project.Aleksa.LevelFinish.Lose
{
    public class LevelLostEvent : MonoBehaviour, IGameLost
    {
        private AnimateLight _lightAnimator;
        private GameObject _gameOverCanvas;

        private void Awake()
        {
            //TODO - Write getters for canvas and animator
            _lightAnimator = FindObjectOfType<AnimateLight>();
            
            _gameOverCanvas = GameObject.Find("LoseCanvas");
            _gameOverCanvas.SetActive(false);
        }
        public void LoseGame()
        {
            _lightAnimator.StartLose();
            AudioHolder.Instance.PowerShutdown();

            ShowCanvasAfterDelay();
        }

        private void ShowCanvasAfterDelay()
        {
            gameObject.AddComponent<TimedAction>().StartTimedAction(ActivateCanvas, 1f);
        }
        private void ActivateCanvas() => _gameOverCanvas.SetActive(true);
    }
}