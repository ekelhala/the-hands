using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectCrane : MonoBehaviour
{
    public LineRenderer mLineRenderer;
    public GameObject a, b;
    // Start is called before the first frame update
    void Start()
    {
        mLineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        mLineRenderer.SetPosition(0, a.transform.position);
        mLineRenderer.SetPosition(1, b.transform.position);
    }
}
