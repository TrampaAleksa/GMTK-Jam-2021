using _Project.Aleksa.Win.ColliderComponents;
using System;
using UnityEngine;

namespace _Project.Aleksa.Signals
{
    [RequireComponent(typeof(LineRend))]
    public class Signal : MonoBehaviour
    {
        public LineRend line;
        public Transform character1;
        public Transform character2;
        public bool canOpenWalls = true;
        public bool onMine;

        private SignalEvent[] _events;
        private bool _isConnected;
        private RaycastHit _hit;
        private RaycastHit rhomb;
        private WinAreaConditions _winAreaConditions;

        public Color interruptedColor;
        public Color regularColor;

        private void Awake()
        {
            line = GetComponent<LineRend>();
            _events = GetComponentsInChildren<SignalEvent>();
            _winAreaConditions = FindObjectOfType<WinAreaConditions>();
        }

        private void Start()
        {
            Connect();

            if (IsInterrupted())
            {
                Disconnect();
            }
        }

        private void Update()
        {
            RhombLogic();
            if (MineLogic())
                return;
            var disconnected = _isConnected && IsInterrupted();
            if (disconnected)
            {
                Disconnect();
            }

            var reconnected = !_isConnected && !IsInterrupted();
            if (reconnected)
            {
                Connect();
                _winAreaConditions.CheckTimerAndWinConditions();
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
        
        private bool ThroughRhomb()
        {
            var receiverPosition = character1.position;
            var broadcasterPosition = character2.position;

            if (Physics.Linecast(broadcasterPosition, receiverPosition, out _hit, LayerMask.GetMask("Devices")))
            {
                if (_hit.collider.gameObject.CompareTag("Rhomb"))
                {
                    rhomb = _hit;
                    return true;
                }
            }
            return false;
        }       
        private void RhombLogic()
        {
            var throughRhomb = _isConnected && ThroughRhomb();
            if (throughRhomb)
            {
                if (canOpenWalls)
                {
                    rhomb.transform.GetComponent<Rhomb>().MoveWallsDown();
                    canOpenWalls = false;
                }
            }
            else
            {
                if (!canOpenWalls)
                {
                    rhomb.transform.GetComponent<Rhomb>().MoveWallsUp();
                    canOpenWalls = true;
                }
            }
        } 
        
        private bool MineLogic()
        {
            if (onMine)
            {
                Disconnect();
                SignalLineDrawer.Draw(this);
                return true;
            }return false;
        }
        public bool Connected => _isConnected;

        public void ChangeSignalColor(Color signalColor)
        {
            line.SetColors(signalColor);
        }
        public void SetSignalPositions(Vector3 startPos, Vector3 endPos)
        {
            line.SetPositions(startPos, endPos);
        }
    }
}