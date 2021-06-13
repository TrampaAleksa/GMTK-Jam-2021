using System;
using UnityEngine;

namespace _Project.Aleksa
{
    public class AudioHolder : MonoBehaviour
    {
        public static AudioHolder Instance;
        
        public AudioSource SwitchCharacter1;
        public AudioSource SwitchCharacter2;

        public AudioSource ClockTickSlow;
        public AudioSource ClockTickNormal;

        public AudioSource PowerDown;
        public AudioSource PowerRestored;
        public AudioSource WinAreaEnter;

        public AudioSource SignalDisconnect;
        public AudioSource SlidingDoor;

        private void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else Destroy(gameObject);
        }
    }
}