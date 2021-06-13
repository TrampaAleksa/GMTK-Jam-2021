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
        private CharacterIndicator[] _indicators;

        private int _charactersInArea;


        private void Awake()
        {
            _winEvents = GetComponentsInChildren<WinEvent>();
            _signals = FindObjectsOfType<Signal>();
            _indicators = FindObjectsOfType<CharacterIndicator>();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Character"))
                return;

            if (_charactersInArea < _indicators.Length)
                _indicators[_charactersInArea].TurnOn();
            
            AudioHolder.Instance.WinAreaEnter.Play();

            _charactersInArea++;
        }

        public void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("Character"))
                return;

            _charactersInArea--;
            
            if (_charactersInArea < _indicators.Length)
                _indicators[_charactersInArea].TurnOff();
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