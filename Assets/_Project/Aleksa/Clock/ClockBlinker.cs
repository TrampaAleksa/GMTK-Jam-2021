using System.Collections;
using UnityEngine;

namespace _Project.Aleksa.Clock
{
    public class ClockBlinker
    {
        public static IEnumerator FlashSprite(Material renderer, float minAlpha, float maxAlpha, float interval, float duration)
        {
            Color colorNow = renderer.color;
            Color minColor = new Color(renderer.color.r, renderer.color.g, renderer.color.b, minAlpha);
            Color maxColor = new Color(renderer.color.r, renderer.color.g, renderer.color.b, maxAlpha);

            float currentInterval = 0;
            while(duration > 0)
            {
                float tColor = currentInterval / interval;
                renderer.color = Color.Lerp(minColor, maxColor, tColor);

                currentInterval += Time.deltaTime;
                if(currentInterval >= interval)
                {
                    Color temp = minColor;
                    minColor = maxColor;
                    maxColor = temp;
                    currentInterval = currentInterval - interval;
                }
                duration -= Time.deltaTime;
                yield return null;
            }

            renderer.color = colorNow;
        }
    }
}