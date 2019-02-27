using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopmove : MonoBehaviour
{
    public Vector3 pos;

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Transform>().position = new Vector3(300, 0, 400) + pos;

        this.GetComponent<Rigidbody>().freezeRotation = true;
    }
}
