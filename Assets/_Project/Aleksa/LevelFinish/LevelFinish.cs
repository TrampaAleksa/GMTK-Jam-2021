using System;
using _Project.Aleksa.Sounds;
using UnityEngine;

namespace _Project.Aleksa.End
{
    /// <summary>
    /// Contains lists of events that relate to different situations that finish the current level.
    /// For eg. winning the level, losing the game via timer, or finishing the last level.
    /// </summary>
    public class LevelFinish : MonoBehaviour
    {
        private IGameLost _lostLevelEvent;

        public void Awake()
        {
            _lostLevelEvent = GetComponent<LevelLostEvent>();
            if (_lostLevelEvent == null) GetNullImplementation();
        }

        public void LoseGame()
        {
            Debug.Log("You lost");
            _lostLevelEvent.LoseGame();
        }

        public void WinGame()
        {
        }


        
        
        private void GetNullImplementation()
        {
            Debug.LogWarning("No lost level event component found, returning null implementation", this);
            _lostLevelEvent = gameObject.AddComponent<NullLevelLostEvent>();
        }
    }
}