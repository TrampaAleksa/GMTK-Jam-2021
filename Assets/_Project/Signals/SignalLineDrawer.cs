
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
    }
}