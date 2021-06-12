using UnityEngine;

namespace _Project.Aleksa.Signals
{
    public class SignalPulse : MonoBehaviour
    {
        public LineRenderer line;
        public Vector2 pulseSpeed;
        private static readonly int BaseColorMap = Shader.PropertyToID("_BaseColorMap");
        private static readonly int EmissionColorMap = Shader.PropertyToID("_EmissiveColorMap");
        public Vector2 offset;
        private void Update()
        {
            var material = line.material;
            offset -= pulseSpeed;

            material.SetTextureOffset(
                BaseColorMap,
                offset);
            material.SetTextureOffset(
                EmissionColorMap,
                offset);
        }
    }
}
