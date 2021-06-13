using UnityEngine;

namespace _Project.Aleksa
{
    public class BackgroundMusic : MonoBehaviour
    {
        public static BackgroundMusic Instance;

        public AudioSource music;
        private void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;

                new AudioSourceFader(music, 1f, 0.3f).StartFading();
            }
            else Destroy(gameObject);
        }
    }
}