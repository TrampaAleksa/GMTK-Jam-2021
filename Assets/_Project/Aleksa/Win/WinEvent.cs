using System;
using _Project.Aleksa.Sounds;
using UnityEngine;

namespace _Project.Aleksa.Win
{
    public class WinEvent : MonoBehaviour
    {
        [SerializeField]
        private AnimateLight animateLight;

        private void Awake()
        {
            animateLight = GetLightAnimations();
        }

        public virtual void Win()
        {
            Debug.Log("Won the game");
            AudioHolder.Instance.PowerRestore();
            animateLight.StartWin();
        }
        
        
        private AnimateLight GetLightAnimations()
        {
            var lightAnimations = FindObjectOfType<AnimateLight>();
            
            if (lightAnimations == null)
            {
                Debug.LogWarning("No lost light animator component found, returning null implementation", this);
                lightAnimations = gameObject.AddComponent<AnimateLight>();
            }

            return lightAnimations;
        }
    }
}