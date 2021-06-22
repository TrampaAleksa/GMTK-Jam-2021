using System.Linq;
using _Project.Aleksa.Signals;
using UnityEngine;

namespace _Project.Aleksa.Win.ColliderComponents
{
    public class WinAreaConditions : MonoBehaviour
    {
        public int charactersToWin;
        
        private int _charactersInArea;
        private Signal[] _signals;

        private void Awake()
        {
            _signals = FindObjectsOfType<Signal>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Character"))
                _charactersInArea++;
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Character"))
                _charactersInArea--;
        }

        public bool IsWinConditionMet()
        {
            if (!AllSignalsConnected) return false;
            if (!AllCharactersInArea) return false;

            return true;
        }
        private bool AllSignalsConnected => _signals.All(signal => signal.Connected);
        private bool AllCharactersInArea => _charactersInArea >= charactersToWin;
    }
}