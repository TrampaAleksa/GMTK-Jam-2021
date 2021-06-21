using System;
using _Project.Aleksa.Sounds;
using UnityEngine;

namespace _Project.Aleksa.End
{
    public class LevelLostEvent : MonoBehaviour, IGameLost
    {
        [SerializeField]
        private AnimateLight lightAnimator;
        [SerializeField]
        private GameObject gameOverCanvas;

        private void Awake()
        {
            //TODO - Add Receiver interfaces that will be received from providers on scene level
            lightAnimator = FindObjectOfType<AnimateLight>();
            gameOverCanvas = GameObject.Find("LoseCanvas");
            gameOverCanvas.SetActive(false);
        }
        public void LoseGame()
        {
            lightAnimator.StartLose();
            AudioHolder.Instance.PowerShutdown();

            ShowCanvasAfterDelay();
        }

        private void ShowCanvasAfterDelay()
        {
            gameObject.AddComponent<TimedAction>().StartTimedAction(ActivateCanvas, 1f);
        }

        private void ActivateCanvas() => gameOverCanvas.SetActive(true);
    }

    public interface IGameLost
    {
        void LoseGame();
    }
}