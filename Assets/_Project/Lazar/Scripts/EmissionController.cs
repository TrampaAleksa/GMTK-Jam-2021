using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EmissionController : MonoBehaviour
{
    public MeshRenderer mesh;
    public float intensity;
    public void SetCustomMaterialEmissionIntensity(MeshRenderer mesh,float intensity)
    {
        Color color = mesh.material.GetColor("_Color");

        float adjustedIntensity = intensity - (0.4169F);

        color *= Mathf.Pow(2.0F, adjustedIntensity);
        DOTween.To(() => mesh.material.GetColor("_EmissionColor"), x => mesh.material.SetColor("_EmissionColor", x), color, 0.3f).SetEase(Ease.Flash);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            SetCustomMaterialEmissionIntensity(mesh, 8);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SetCustomMaterialEmissionIntensity(mesh, 1);
        }
    }
}
