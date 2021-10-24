using System;
using UnityEngine;

namespace _Project.Aleksa.Win
{
    public class CharacterIndicator : MonoBehaviour
    {
        private MeshRenderer _renderer;
        public float turnedOnIntensity;
        public Color color;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
        }
        private void Start()
        {
            var propBlick = new MaterialPropertyBlock();
            _renderer.GetPropertyBlock(propBlick);
            color = _renderer.material.GetColor("_EmissionColor");
        }

        //TODO - Fix mini bug where diode can 'overheat' if turned on / off multiple times
        public void TurnOn()
        {
            EmissionController.Instance.SetCustomMaterialEmissionIntensity(_renderer, turnedOnIntensity); 
        }

        public void TurnOff()
        {
            EmissionController.Instance.SetCustomMaterialEmissionIntensity(_renderer, color);
        }
    }
}