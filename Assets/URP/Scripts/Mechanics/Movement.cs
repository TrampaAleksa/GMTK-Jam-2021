using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float turnSmoothTime = 0.1f;
    
    float turnSmoothVelocity;
    Rigidbody rb;
    Transform cam;
    Transform playerTransform;

    Animator animator;
    static readonly int IsWalking = Animator.StringToHash("isWalking");

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = cam == null ? Camera.main.transform : cam;
        playerTransform = transform;
        animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(playerTransform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            playerTransform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            rb.MovePosition(playerTransform.position + moveDir.normalized * (movementSpeed * Time.deltaTime));
            animator.SetBool(IsWalking, true);
            return;
        }
        animator.SetBool(IsWalking, false);
    }

}
