using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCrane : MonoBehaviour
{
    [SerializeField]public float speed;
    private bool isMovingDown = false;
    private bool isMovingUp = false;
    private bool isMovingLeft = false;
    private bool isMovingRight = false;
    [SerializeField]private GameObject cylinder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMovingDown)
            Down();
        if(isMovingUp)
            Up();
        if(isMovingLeft)
            Left();
        if(isMovingRight)
            Right();
    }

    public void StartMovement(string direction) {
        if(direction == "up")
            isMovingUp = true;
        else if(direction == "down")
            isMovingDown = true;
        else if(direction == "left")
            isMovingLeft = true;
        else if(direction == "right")
            isMovingRight = true;
    }

    public void StopMovement() {
        isMovingDown = false;
        isMovingUp = false;
        isMovingLeft = false;
        isMovingRight = false;
    }

    private void Down() {
        Vector3 newPosition = cylinder.transform.position;
        newPosition.y -= speed;
        cylinder.transform.position = newPosition;
    }

    private void Up() {
        Vector3 newPosition = cylinder.transform.position;
        newPosition.y += speed;
        cylinder.transform.position = newPosition;
    }

    private void Right()
    {
        Vector3 newPosition = transform.position;
        newPosition.x += speed;
        transform.position = newPosition;
    }

    private void Left()
    {
        Vector3 newPosition = transform.position;
        newPosition.x -= speed;
        transform.position = newPosition;    }

}
