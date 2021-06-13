using System;
using UnityEngine;

public class PlayerArrow : MonoBehaviour
{
    private Transform _transform;

    public float UpperLimit;
    private Quaternion _initialRotation;

    private void Awake()
    {
        _transform = transform;
        _initialRotation = _transform.rotation;
    }

    private void Update()
    {
        _transform.rotation = _initialRotation;
    }

    public void SetNewPlayer(Transform playerTransform)
    {
        _transform.parent = playerTransform;
        _transform.position = playerTransform.position + Vector3.up * UpperLimit;
    }
}