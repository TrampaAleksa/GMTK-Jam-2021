using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EmissionController : MonoBehaviour
{
    public static EmissionController Instance;
    private MaterialPropertyBlock propBlock;
    private void Awake()
    {
        if (Instance==null)
            Instance = this;
        propBlock = new MaterialPropertyBlock();
    }
    public void ToggleEmission(bool isEnable, MeshRenderer renderer)
    {
        if (isEnable)
            renderer.material.EnableKeyword("_EMISSION");
        else
            renderer.material.DisableKeyword("_EMISSION");
    }
}
