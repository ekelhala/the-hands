using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMagnet : MonoBehaviour
{
    public float forceFactor = 200f;
    List<Rigidbody> targets = new List<Rigidbody>();
    Transform magnetP;
    // Start is called before the first frame update
    void Start()
    {
         magnetP = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() {
    foreach (Rigidbody target in targets)
    {
        target.AddForce((magnetP.position - target.position) * forceFactor * Time.fixedDeltaTime);
    }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Container")){
            targets.Add(other.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Container")){
            targets.Remove(other.GetComponent<Rigidbody>());
        }
    }
}
