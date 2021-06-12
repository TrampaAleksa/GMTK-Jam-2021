using System.Linq;
using _Project.Aleksa.Signals;
using UnityEngine;

namespace _Project.Aleksa.Win
{
    public class WinArea : MonoBehaviour
    {
        public int numberToWin;

        private WinEvent[] _winEvents;
        private Signal[] _signals;
        private int _charactersInArea;

        private void Awake()
        {
            _winEvents = GetComponentsInChildren<WinEvent>();
            _signals = FindObjectsOfType<Signal>();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Character"))
                return;

            _charactersInArea++;
        }

        public void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("Character"))
                return;

            _charactersInArea--;
        }

        private void Update()
        {
            if (IsWinConditionMet())
                WinTheLevel();
        }

        private bool IsWinConditionMet()
        {
            if (!AllSignalsConnected) return false;
            if (!AllCharactersInArea) return false;

            return true;
        }

        private void WinTheLevel()
        {
            foreach (var winEvent in _winEvents)
            {
                winEvent.Win();
            }

            enabled = false;
        }

        private bool AllSignalsConnected => _signals.All(signal => signal.Connected);

        private bool AllCharactersInArea => _charactersInArea >= numberToWin;
    }
}