using System;
using _Project.Aleksa.Sounds;
using _Project.Aleksa.Util;
using UnityEngine;

namespace _Project.Aleksa.Win
{
    public class WinEvent : MonoBehaviour, ILevelWonEvent
    {
        [SerializeField] private AnimateLight animateLight;
        private GameObject _canvas;

        private void Awake()
        {
            animateLight = GetLightAnimations();
            _canvas = GetGameWonCanvas();
        }

        public void Win()
        {
            Debug.Log("Won the game");
            AudioHolder.Instance.PowerRestore();
            animateLight.StartWin();
            ShowCanvasAfterDelay();
        }
        
        private void ShowCanvasAfterDelay()
        {
            gameObject.AddComponent<TimedAction>().StartTimedAction(ActivateCanvas, 1f);
        }
        private void ActivateCanvas() => _canvas.SetActive(true);

        
        
        //TODO - Multiple places where we get light animations and get canvas, maye extract Provider methods
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
        private GameObject GetGameWonCanvas()
        {
            var gameOverCanvas = GameObject.Find("WinCanvas");
            
            if (gameOverCanvas == null)
            {
                Debug.LogWarning("No canvas found, returning empty game object", this);
                gameOverCanvas = new GameObject("empty game won canvas");
            }

            gameOverCanvas.SetActive(false);
            return gameOverCanvas;
        }
    }
}