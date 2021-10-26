using _Project.Aleksa.Sounds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Test : MonoBehaviour
{
    public static Test Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    float[] Samples= new float[512];
    
    public float[] freqband= new float[8];

    private void Update()
    {
        AudioHolder.Instance.GetBackgoundMusic().GetSpectrumData(Samples, 0, FFTWindow.Blackman);

        int count = 0;
        for(int i = 0; i < 8; i++)
        {
            float avg = 0;
            int sample = (int)Mathf.Pow(2, i)*2;

            if (i == 7)
            {
                sample += 2;
            }
            for(int j = 0; j < sample; j++)
            {
                avg+=Samples[count] * (count+1);
                count++;
            }
            avg /= count;

            freqband[i] = avg*10;
        }
    }
}
