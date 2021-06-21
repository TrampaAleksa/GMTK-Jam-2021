using UnityEngine;

namespace _Project.Aleksa.Sounds
{
    public class BackgroundMusic : MonoBehaviour
    {
        private void Start()
        {
            AudioHolder.Instance.StartBackgroundMusic();
        }
    }
}