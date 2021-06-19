using System;
using UnityEngine;

namespace _Project.Aleksa.End
{
    public class GameLostCanvasDisplayEvent : GameLostLevelFinishEvent
    {
        public float canvasDisplayDelay = 1f;
        
        [SerializeField]
        private GameObject gameOverCanvas;

        private void Awake()
        {
            //todo -remove game object find via name
            gameOverCanvas = GameObject.Find("LoseCanvas");
            gameOverCanvas.SetActive(false);
        }

        public override void FinishLevel()
        {
            canvasDisplayDelay = 1.8f;
            gameObject.AddComponent<TimedAction>().StartTimedAction(ActivateCanvas, canvasDisplayDelay);
        }
        private void ActivateCanvas() => gameOverCanvas.SetActive(true);
    }
}