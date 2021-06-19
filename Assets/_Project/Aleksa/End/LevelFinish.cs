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
        private GameLostLevelFinishEvent[] _gameOverEvents;

        public void Init()
        {
            _gameOverEvents = GetComponentsInChildren<GameLostLevelFinishEvent>();
        }

        public void LoseGame()
        {
            Debug.Log("You lost");

            foreach (var gameLostEvent in _gameOverEvents)
            {
                gameLostEvent.FinishLevel();
            }
        }
    }
}