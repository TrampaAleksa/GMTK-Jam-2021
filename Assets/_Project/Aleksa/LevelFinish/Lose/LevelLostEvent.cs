using _Project.Aleksa.Sounds;
using _Project.Aleksa.Util;
using UnityEngine;

namespace _Project.Aleksa.LevelFinish.Lose
{
    public class LevelLostEvent : MonoBehaviour, IGameLost
    {
        private AnimateLight _lightAnimator;
        private GameObject _gameOverCanvas;

        private void Awake()
        {
            _lightAnimator = GetLightAnimations();
            _gameOverCanvas = GetGameLoseCanvas();
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

        

        private AnimateLight GetLightAnimations()
        {
            var lightAnimations = FindObjectOfType<AnimateLight>();
            
            if (lightAnimations == null)
            {
                Debug.LogWarning("No lost light animator component found, returning null implementation", this);
                lightAnimations = gameObject.AddComponent<AnimateLight>();
            }

            return lightAnimations;
        }
        
        private GameObject GetGameLoseCanvas()
        {
            var gameOverCanvas = GameObject.Find("LoseCanvas");
            
            if (gameOverCanvas == null)
            {
                Debug.LogWarning("No canvas found, returning empty game object", this);
                gameOverCanvas = new GameObject("empty game lost canvas");
            }

            gameOverCanvas.SetActive(false);
            return gameOverCanvas;
        }
    }
}