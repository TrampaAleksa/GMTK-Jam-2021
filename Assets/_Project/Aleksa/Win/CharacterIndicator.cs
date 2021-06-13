using UnityEngine;

namespace _Project.Aleksa.Win
{
    public class CharacterIndicator : MonoBehaviour
    {
        private MeshRenderer _renderer;
        public float turnedOnIntensity;
        public float initialIntensity;
        
        public void TurnOn()
        {
            EmissionController.SetCustomMaterialEmissionIntensity(_renderer, turnedOnIntensity);
        }

        public void TurnOff()
        {
            EmissionController.SetCustomMaterialEmissionIntensity(_renderer, initialIntensity);

        }
    }
}