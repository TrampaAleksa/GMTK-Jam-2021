using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Aleksa.Win.ColliderComponents
{
    public class WinAreaCharacterIndicators : MonoBehaviour
    {
       private CharacterIndicator[] _indicators; //TODO - Use stack (or queue) for indicators, will remove need for memorizing no. of chars
       private int _charactersInArea;
        private bool lightIsOn = false;
        private List<Signals.Signal> charSignals;       

       private void Awake()
       {
           _indicators = FindObjectsOfType<CharacterIndicator>();
            charSignals = new List<Signals.Signal>();
       }
       
       public void OnTriggerEnter(Collider other)
       {
            if (other.gameObject.CompareTag("Character"))
            {
                //Method is used if you want indicators to turn on only if all signals from that character are connected.
                //If you use first method then comment next line.
                //TurnIndicatorsIfSignalsAreConnected(other);
                _indicators[_charactersInArea++].TurnOn();
            }
       }

       public void OnTriggerExit(Collider other)
       {
            if (other.gameObject.CompareTag("Character"))  //&& lightIsOn == true)
            {
                _indicators[--_charactersInArea].TurnOff();
               // lightIsOn = false;
            }
       }

        private void TurnIndicatorsIfSignalsAreConnected(Collider other)
        {
            Signals.Signal[] signals = GameObject.FindObjectsOfType<Signals.Signal>();
            foreach (Signals.Signal signal in signals)
            {
                // problem kad ima 2 signala
                if (signal.GetComponent<Signals.Signal>().character1 == other.transform ||
                    signal.GetComponent<Signals.Signal>().character2 == other.transform)
                {
                    charSignals.Add(signal);

                }
            }
            foreach (Signals.Signal signal1 in charSignals)
            {
                if (!signal1.GetComponent<Signals.Signal>().Connected)
                {
                    charSignals.Clear();
                    return;
                }
            }
            if (lightIsOn == false)
            {
                _indicators[_charactersInArea++].TurnOn();
                lightIsOn = true;
                charSignals.Clear();
            }
        }
    }
}