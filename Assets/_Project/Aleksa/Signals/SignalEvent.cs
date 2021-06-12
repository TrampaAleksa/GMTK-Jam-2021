using UnityEngine;

namespace _Project.Aleksa.Signals
{
    public class SignalEvent : MonoBehaviour
    {
    
        public virtual void OnConnect(Signal signal)
        {
            
        }

        public virtual void OnDisconnect(Signal signal)
        {
        }
    }
}