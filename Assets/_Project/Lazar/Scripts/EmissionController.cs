using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EmissionController : MonoBehaviour
{
    public static EmissionController Instance;
    private MaterialPropertyBlock propBlick;
    private void Awake()
    {
        if (Instance==null)
            Instance = this;
        propBlick = new MaterialPropertyBlock();
    }
    public void SetCustomMaterialEmissionIntensity(MeshRenderer meshRender, float intensity)
    {
        meshRender.GetPropertyBlock(propBlick);
        Color color = meshRender.material.GetColor("_EmissionColor") * intensity;

        DOTween.To(() => meshRender.material.GetColor("_EmissionColor"),
            x =>{
            propBlick.SetColor("_EmissionColor", x);
            meshRender.SetPropertyBlock(propBlick);
            },
            color, 0.3f)
            .SetEase(Ease.Flash);
    }

    public void SetCustomMaterialEmissionIntensity(MeshRenderer meshRender, Color color)
    {
        DOTween.To(() => meshRender.material.GetColor("_EmissionColor"),
            x => {
                propBlick.SetColor("_EmissionColor", x);
                meshRender.SetPropertyBlock(propBlick);
            },
            color*0, 0.3f)
            .SetEase(Ease.Flash);
    }
}
