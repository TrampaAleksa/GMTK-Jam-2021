using System;
using UnityEngine;

namespace _Project.Aleksa.Win
{
    public class CharacterIndicator : MonoBehaviour
    {
        private MeshRenderer _renderer;
        public float turnedOnIntensity;
        public float initialIntensity;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
           TurnOff();
        }

        //TODO - Fix mini bug where diode can 'overheat' if turned on / off multiple times
        public void TurnOn()
        {
            EmissionController.SetCustomMaterialEmissionIntensity(_renderer, turnedOnIntensity); 
        }

        public void TurnOff()
        {
            EmissionController.SetCustomMaterialEmissionIntensity(_renderer, initialIntensity);
        }
    }
}