using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [Header("추격 대상")]
    public Transform kFollowTarget;

    [Header("추격 강도")]
    public float kFollowTensor = 10f;

    Vector3 mTargetDistance;
    void Start()
    {
        mTargetDistance = transform.position - kFollowTarget.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, kFollowTarget.position + mTargetDistance, kFollowTensor * Time.deltaTime);
    }
}
