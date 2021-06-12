using System;
using UnityEditor;
using UnityEngine;

namespace _Project.Aleksa
{
    public class SwitchCharactersTooltip : MonoBehaviour
    {
        public GameObject Tooltip1;
        public GameObject Tooltip2;

        private bool firstActive;

        private void Start()
        {
            Tooltip1.SetActive(false);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (firstActive) 
                {
                    Tooltip1.SetActive(false);
                    Tooltip2.SetActive(true);
                    firstActive = false;
                    return;
                }
                
                Tooltip1.SetActive(true);
                Tooltip2.SetActive(false);
                firstActive = true;

            }
        }
    }
}