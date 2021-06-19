using UnityEngine;

namespace _Project.Aleksa.End
{
    public class GameLostCanvasDisplayEvent : GameLostLevelFinishEvent
    {
        public float canvasDisplayDelay = 1f;
        
        [SerializeField]
        private GameObject gameOverCanvas; 

        public override void Finish()
        {
            canvasDisplayDelay = 1.8f;
            gameObject.AddComponent<TimedAction>().StartTimedAction(ActivateCanvas, canvasDisplayDelay);
        }
        private void ActivateCanvas() => gameOverCanvas.SetActive(true);
    }
}