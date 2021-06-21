using UnityEngine;

namespace _Project.Aleksa.Util
{
    public class FixRotations : MonoBehaviour
    {
        private Transform _transform;
        private Quaternion initialPosition;

        private void Awake()
        {
            _transform = transform;
            initialPosition = _transform.rotation;
        }

        private void Update()
        {
            _transform.rotation = initialPosition;
        }
    }
}