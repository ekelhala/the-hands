using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class HandController : MonoBehaviour
{
    ActionBasedController myController;
    public InputActionReference gripAction;
    public InputActionReference triggerAction;

    public Hand hand;
    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<ActionBasedController>();
        gripAction.action.Enable();
        triggerAction.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        hand.setGrip(gripAction.action.ReadValue<float>());
        hand.setTrigger(triggerAction.action.ReadValue<float>());
    }
}
