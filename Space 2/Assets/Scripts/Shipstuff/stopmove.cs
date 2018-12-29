using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopmove : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Transform>().position = new Vector3(300, 0, 400);
        this.GetComponent<Rigidbody>().freezeRotation = true;
    }
}
