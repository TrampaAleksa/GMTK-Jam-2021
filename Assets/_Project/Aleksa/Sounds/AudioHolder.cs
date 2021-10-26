using UnityEngine;

namespace _Project.Aleksa.Sounds
{
    public class AudioHolder : MonoBehaviour
    {
        public static AudioHolder Instance;

        [SerializeField]
        private AudioSource SwitchCharacter1, SwitchCharacter2;

        [SerializeField]
        private AudioSource Alarm;

        [SerializeField]
        private AudioSource PowerDown;
        [SerializeField]
        private AudioSource PowerRestored;
        [SerializeField]
        private AudioSource WinAreaEnter;

        [SerializeField]
        private AudioSource ButtonActivated;

        [SerializeField]
        private AudioSource backgroundMusic;

        public AudioSource GetBackgoundMusic()
        {
            return backgroundMusic;
        }
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
        }
        public void AlarmStop()
        {
            //TODO - Add small alarm cooldown once turned off
            new AudioSourceFader(Alarm, 2f, 0f).StartFading();
        }

        public void PowerShutdown()
        {
            PowerDown.Play();
            AlarmStop();
        }
        public void PowerRestore()
        {
            PowerRestored.Play();
            AlarmStop();
        }

        public void EnteredWinArea()
        {
           WinAreaEnter.Play();
        }

        public void ActivateButton(ButtonSoundType type)
        {
           ButtonActivated.Play();
        }

        public void StartBackgroundMusic()
        {
            new AudioSourceFader(backgroundMusic, 1f, 0.3f).StartFading(gameObject);
        }
    }
}