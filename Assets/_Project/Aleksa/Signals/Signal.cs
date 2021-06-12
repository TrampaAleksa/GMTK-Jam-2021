using UnityEngine;

namespace _Project.Aleksa.Signals
{
    public class Signal : MonoBehaviour
    {
        public LineRenderer line;
        public Transform character1;
        public Transform character2;

        private SignalEvent[] _events;
        private bool _isConnected;
        private RaycastHit _hit;

        public Color interruptedColor;
        public Color regularColor;

        private void Awake()
        {
            _events = GetComponentsInChildren<SignalEvent>();

            if (IsInterrupted())
            {
                line.startColor = interruptedColor;
                line.endColor= interruptedColor;
            }
        }

        private void Update()
        {
            var disconnected = _isConnected && IsInterrupted();
            if (disconnected)
            {
                Disconnect();
            }

            var reconnected = !_isConnected && !IsInterrupted();
            if (reconnected)
            {
                Connect();
            }
        
            SignalLineDrawer.Draw(this);
        }

        private void Disconnect()
        {
            foreach (var eSignalEvent in _events)
            {
                eSignalEvent.OnDisconnect(this);
            }
            Debug.Log("disconnected");
            _isConnected = false;
        }

        private void Connect()
        {
            foreach (var eSignalEvent in _events)
            {
                eSignalEvent.OnConnect(this);
            }

            Debug.Log("connected");
            _isConnected = true;
        }

        private bool IsInterrupted()
        {
            var receiverPosition = character1.position;
            var broadcasterPosition = character2.position;

            return Physics.Linecast(broadcasterPosition, receiverPosition, out _hit, LayerMask.GetMask("Wall"));
        }

        public bool Connected => _isConnected;
    }
}