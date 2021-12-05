using System;
using System.Linq;
using _Project.Aleksa.Alarm;
using _Project.Aleksa.Signals;
using UnityEngine;

namespace _Project.Aleksa.Win.ColliderComponents
{
    public class WinAreaConditions : MonoBehaviour
    {
        //TODO - null pattern for fields
        public int charactersToWin;

        private int _charactersInArea;

        private Alarm.Alarm _alarm;
        private WinArea _winArea;
        private Signal[] _signals;

        private void Awake()
        {
            _winArea = GetComponent<WinArea>();
            _signals = FindObjectsOfType<Signal>();
            _alarm = FindObjectOfType<Alarm.Alarm>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Character"))
            {
                _charactersInArea++;
                CheckWinConditions();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Character"))
                _charactersInArea--;
        }
        public void CheckTimerAndWinConditions()
        {
            if (AllSignalsConnected) _alarm.StopTimer();
            CheckWinConditions();
        }
        private void CheckWinConditions()
        {
            print("1");
            if (IsWinConditionMet())
            {
                _winArea.WinTheLevel();
                enabled = false;
                SceneHandler.Instance.UnlockNewLevel();
            }
        }

        private bool IsWinConditionMet()
        {
            if (!AllSignalsConnected) return false;
            if (!AllCharactersInArea) return false;

            return true;
        }
        private bool AllSignalsConnected => _signals.All(signal => signal.Connected);
        private bool AllCharactersInArea => _charactersInArea >= charactersToWin;
    }
}