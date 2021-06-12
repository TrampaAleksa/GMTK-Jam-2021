using System;
using UnityEngine;

namespace _Project.Win
{
    public class WinArea : MonoBehaviour
    {
        public int numberToWin;

        private WinEvent[] _winEvents;
        private int _charactersInArea;

        private void Awake()
        {
            _winEvents = GetComponentsInChildren<WinEvent>();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Character"))
                return;
            
            
            _charactersInArea++;
            if (_charactersInArea < numberToWin)
                return;

            //TODO - Add signal not disconnected condition
            foreach (var winEvent in _winEvents)
            {
                winEvent.Win();
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("Character"))
                return;
            
            _charactersInArea--;
        }
    }
}