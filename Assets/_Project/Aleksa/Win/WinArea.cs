using _Project.Aleksa.Sounds;
using UnityEngine;

namespace _Project.Aleksa.Win
{
    public class WinArea : MonoBehaviour
    {
        private ILevelWonEvent _levelWonEvent;

        private void Awake()
        {
            _levelWonEvent = GetComponentInChildren<ILevelWonEvent>(); // todo - use null pattern
        }

        public void WinTheLevel()
        {
            _levelWonEvent.Win();
            enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Character"))
                AudioHolder.Instance.EnteredWinArea();
        }
    }
}