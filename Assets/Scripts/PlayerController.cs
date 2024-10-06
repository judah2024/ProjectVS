using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float fMoveSpeed = 20.0f;
    public float kRotateSpeed = 10.0f;

    Vector3 mOldPosition;
    Animator mAnimator;

    void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0, z).normalized;

        Vector3 newPosition = transform.position + dir * fMoveSpeed * Time.deltaTime;
        
        mAnimator.SetBool("IsMove", dir != Vector3.zero);

        transform.position = newPosition;
    }

    void Rotate()
    {
        Vector3 tankForward = transform.position - mOldPosition;
        if (tankForward.magnitude >= 0.01f)
        {
            float signedAngleY = Vector3.SignedAngle(Vector3.forward, tankForward, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, signedAngleY, 0.0f), Time.deltaTime * kRotateSpeed);
            mOldPosition = transform.position;
        }
    }
}
