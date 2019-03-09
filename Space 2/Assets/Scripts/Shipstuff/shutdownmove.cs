using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shutdownmove : MonoBehaviour
{
    public move m;
    public GameObject cam;
    public GameObject ss;

    // Update is called once per frame
    void Update()
    {
        cam.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ss.GetComponent<Rigidbody>().velocity = Vector3.zero;
        m.enabled = false;
        enabled = false;
    }
}
