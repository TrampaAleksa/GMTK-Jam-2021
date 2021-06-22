using System;
using UnityEngine;

namespace _Project.Aleksa.Win.ColliderComponents
{
    public class WinAreaCharacterIndicators : MonoBehaviour
    {
       private CharacterIndicator[] _indicators; //TODO - Use stack (or queue) for indicators, will remove need for memorizing no. of chars
       private int _charactersInArea;

       private void Awake()
       {
           _indicators = FindObjectsOfType<CharacterIndicator>();
       }
       
       public void OnTriggerEnter(Collider other)
       {
           if (other.gameObject.CompareTag("Character"))
               _indicators[_charactersInArea++].TurnOn();
       }

       public void OnTriggerExit(Collider other)
       {
           if (other.gameObject.CompareTag("Character"))
               _indicators[--_charactersInArea].TurnOff();
       }
    }
}