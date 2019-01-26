using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class samevalue : MonoBehaviour
{
    Noise noise = new Noise();
    public Vector3 point;


    // Update is called once per frame
    void Update()
    {
        Debug.Log(point * noise.Evaluate(point));
    }
}
