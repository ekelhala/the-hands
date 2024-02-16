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
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
