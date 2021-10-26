using System;
using UnityEngine;

namespace _Project.Aleksa.Win
{
    public class CharacterIndicator : MonoBehaviour
    {
        private MeshRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        //TODO - Fix mini bug where diode can 'overheat' if turned on / off multiple times
        public void TurnOn()
        {
            _renderer.material.EnableKeyword("_EMISSION"); 
        }

        public void TurnOff()
        {

            _renderer.material.DisableKeyword("_EMISSION");
        }
    }
}