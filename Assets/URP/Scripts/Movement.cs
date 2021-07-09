using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;
    private Rigidbody _rb;
    private Transform _cam;
    private Transform _playerTransform;

    private Animator animator;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _cam = _cam == null ? Camera.main.transform : _cam;
        _playerTransform = transform;
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(_playerTransform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            _playerTransform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            _rb.MovePosition(_playerTransform.position + moveDir.normalized * (movementSpeed * Time.deltaTime));
            animator.SetBool(IsWalking, true);
            return;
        }
        animator.SetBool(IsWalking, false);
    }
}
