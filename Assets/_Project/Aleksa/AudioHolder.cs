using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Aleksa
{
    public class AudioHolder : MonoBehaviour
    {
        public static AudioHolder Instance;
        
        public AudioSource SwitchCharacter1;
        public AudioSource SwitchCharacter2;

        public AudioSource Alarm;

        public AudioSource PowerDown;
        public AudioSource PowerRestored;
        public AudioSource WinAreaEnter;

        public AudioSource ButtonActivated;
        public AudioSource SlidingDoor;

        [SerializeField]
        private AudioSource backgroundMusic;

        private void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else Destroy(gameObject);
        }

        private int _swapIndex;
        public void SwapCharacters()
        {
            if (_swapIndex == 0)
            {
                SwitchCharacter1.Play();
                _swapIndex = 1; 
            }
            else
            {
                SwitchCharacter2.Play();
                _swapIndex = 0;
            }
        }


        public void AlarmStart()
        {
            new AudioSourceFader(Alarm, 1f, 1f).StartFading();
           // Alarm.Play(); 
        }
        public void AlarmStop()
        {
            new AudioSourceFader(Alarm, 2f, 0f).StartFading();
            // Alarm.Stop(); //TODO - Add clock tick cooldown if we stop
        }

        public void StartBackgroundMusic()
        {
            new AudioSourceFader(backgroundMusic, 1f, 0.3f).StartFading(gameObject);
        }
    }
}