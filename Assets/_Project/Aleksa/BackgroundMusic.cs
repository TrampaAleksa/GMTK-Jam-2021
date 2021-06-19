using _Project.Aleksa.Sounds;
using UnityEngine;

namespace _Project.Aleksa
{
    public class BackgroundMusic : MonoBehaviour
    {
        private void Start()
        {
            AudioHolder.Instance.StartBackgroundMusic();
        }
    }
}