using System;
using UnityEngine;

namespace _Project.Aleksa.Clock
{
    public class TimerClock : MonoBehaviour
    {
        public MeshRenderer renderer;
        private void Start()
        {
            StartCoroutine(ClockBlinker.FlashSprite(renderer.material, 15, 255, 2, 16));
        }
    }
}