using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    Animator animator;
    public float speed;
    private float gripTarget, triggerTarget;
    private float gripCurrent, triggerCurrent;
    private const string gripParam = "Grip";
    private const string triggerParam = "Trigger";

    [SerializeField]private GameObject followObject;
    [SerializeField]private float followSpeed = 30f;
    [SerializeField]private float rotateSpeed = 100f;
    [SerializeField]private Vector3 positionOffset;
    [SerializeField]private Vector3 rotationOffset;
    private Transform followTarget;
    private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        followTarget = followObject.transform;
        body = GetComponent<Rigidbody>();
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.mass = 20f;

        body.position = followTarget.position;
        body.rotation = followTarget.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        animateHand();
        physicsMove();
    }

    private void physicsMove() {
        var posWithOffset = followTarget.position + positionOffset;
        var distance = Vector3.Distance(posWithOffset, transform.position);
        body.velocity = (posWithOffset - transform.position).normalized * (followSpeed * distance);
        
        var rotWithOffset = followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotWithOffset * Quaternion.Inverse(body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
    }

    public void setGrip(float value) {
        gripTarget = value;
    }

    public void setTrigger(float value) {
        triggerTarget = value;
    }

    void animateHand() {
        if(gripCurrent != gripTarget) {
            gripCurrent = Mathf.MoveTowards(gripCurrent, gripTarget, Time.deltaTime*speed);
            animator.SetFloat(gripParam, gripCurrent);
        }
        if(triggerCurrent != triggerTarget) {
            triggerCurrent = Mathf.MoveTowards(triggerCurrent, triggerTarget, Time.deltaTime*speed);
            animator.SetFloat(triggerParam, triggerCurrent);
        }
    }
}
