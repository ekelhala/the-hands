using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CraneMagnet : MonoBehaviour
{
   private FixedJoint jointReference;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
        {
        if(collision.gameObject.tag == "Container" && !(collision.gameObject.GetComponent<FixedJoint>())) {
            jointReference = gameObject.AddComponent<FixedJoint>();
            jointReference.anchor = collision.contacts[0].point;
            jointReference.connectedBody = collision.rigidbody;
      }
   }

   public void DetachMagnet() {
      Destroy(jointReference);
   }
}
