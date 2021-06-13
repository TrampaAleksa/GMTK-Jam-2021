using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EmissionController : MonoBehaviour
{
    public static EmissionController Instance;
    private void Awake()
    {
        if(Instance==null)
            Instance = this;
    }
    public static void SetCustomMaterialEmissionIntensity(MeshRenderer mesh,float intensity)
    {
        Color color = mesh.material.GetColor("_EmissionColor");

        float adjustedIntensity = intensity - (0.4169F);

        color *= Mathf.Pow(2.0F, adjustedIntensity);
        DOTween.To(() => mesh.material.GetColor("_EmissionColor"), x => mesh.material.SetColor("_EmissionColor", x), color, 0.3f).SetEase(Ease.Flash);
    }
    
    public static void SetCustomMaterialEmissionIntensityBase(MeshRenderer mesh,float intensity)
    {
        Color color = mesh.material.GetColor("_Color");

        float adjustedIntensity = intensity - (0.4169F);

        color *= Mathf.Pow(2.0F, adjustedIntensity);
        DOTween.To(() => mesh.material.GetColor("_EmissionColor"), x => mesh.material.SetColor("_EmissionColor", x), color, 0.3f).SetEase(Ease.Flash);
    }
}
