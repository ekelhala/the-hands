using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CargoGoal : MonoBehaviour
{
    [SerializeField]public GameObject rig;
    bool reached = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -4.0f && transform.position.y == 1.2f) {
            if(!reached) {
            Vector3 goalPosition = new Vector3(-10.85f, 0.587f, -37.36f);
            rig.transform.position = goalPosition;
            reached = true;
            }
        }
    }
}
