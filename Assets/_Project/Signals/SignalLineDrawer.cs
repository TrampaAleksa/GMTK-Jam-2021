
using UnityEngine;

namespace _Project.Signals
{
    public class SignalLineDrawer
    {
        public static void Draw(Signal signal)
        {
            var receiverPosition = signal.character1.position;
            var broadcasterPosition = signal.character2.position;
        
            signal.line.SetPosition(0, broadcasterPosition);
            signal.line.SetPosition(1, receiverPosition);
        }

        public static bool IsInterrupted(Transform character1, Transform character2)
        {
            var receiverPosition = character1.position;
            var broadcasterPosition = character2.position;

            return Physics.Linecast(broadcasterPosition, receiverPosition, LayerMask.GetMask("Wall"));
        }
    }
}