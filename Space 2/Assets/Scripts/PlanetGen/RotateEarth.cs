using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    private Vector3 position;
    private Rigidbody rb;
    private float Rotationspeed;
    private float distance;
    
    private float rotationspeed2;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        rb = GetComponent<Rigidbody>();
        Rotationspeed = 1;
        float RotateStart = Random.Range(0f, 1f);
        rb.transform.RotateAround(Vector3.zero, Vector3.up, 360 * RotateStart);
        float distance = transform.position.magnitude;
        Debug.Log("The Speed ist equal to    " + distance);
        rotationspeed2 = 200 * Time.deltaTime * Rotationspeed / distance;


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.transform.RotateAround(Vector3.zero, Vector3.up, rotationspeed2);
        
        transform.Rotate(0, 0.1f, 0);
    }
}
