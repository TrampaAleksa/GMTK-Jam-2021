using System.Linq;
using _Project.Aleksa.Signals;
using _Project.Aleksa.Sounds;
using UnityEngine;

namespace _Project.Aleksa.Win
{
    public class WinArea : MonoBehaviour
    {
        public int numberToWin;

        private ILevelWonEvent _levelWonEvent;
        private Signal[] _signals;
        private CharacterIndicator[] _indicators;

        private int _charactersInArea; //TODO - extract characters in area logic into separate class

        private void Awake()
        {
            //todo - create getters that use null pattern
            _levelWonEvent = GetComponentInChildren<ILevelWonEvent>();
            _signals = FindObjectsOfType<Signal>();
            _indicators = FindObjectsOfType<CharacterIndicator>();
        }

        private void Update()
        {
            if (IsWinConditionMet())
                WinTheLevel();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Character"))
                CharacterEnteredWinArea();
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Character"))
                CharacterLeftWinArea();
        }

        private void CharacterEnteredWinArea()
        {
            // if (_charactersInArea < _indicators.Length)
                // _indicators[_charactersInArea].TurnOn();

            AudioHolder.Instance.EnteredWinArea();

            _charactersInArea++;
        }

        private void CharacterLeftWinArea()
        {
            _charactersInArea--;

            // if (_charactersInArea < _indicators.Length)
                // _indicators[_charactersInArea].TurnOff();
        }

        //TODO - Move IsWinConditionMet logic outside of win area class. The area should only be notified once the condition IS met, and not care HOW its met
        //Once we move that logic out we can actually move signals, indicators, and even characters in area references out.
        //All that will be left for the win area is to contain the implementation for finishing a level and knowing when that condition is met.
        private bool IsWinConditionMet()
        {
            if (!AllSignalsConnected) return false;
            if (!AllCharactersInArea) return false;

            return true;
        }

        private void WinTheLevel()
        {
            _levelWonEvent.Win();
            enabled = false;
        }

        private bool AllSignalsConnected => _signals.All(signal => signal.Connected);
        private bool AllCharactersInArea => _charactersInArea >= numberToWin;
    }
}