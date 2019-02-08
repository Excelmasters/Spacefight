using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //this.position = position;
       // this.position = this.position + Vector3.right;
        //this.transform.Rotate
        
        this.transform.Rotate(0, 0.1f, 0);
    }
}
