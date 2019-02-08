using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    private Vector3 position;
    private Rigidbody rb;
    private float Rotationspeed;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        rb = GetComponent<Rigidbody>();
        Rotationspeed = Random.Range(0.5f, 2f);
        float RotateStart = Random.Range(0f, 1f);
        rb.transform.RotateAround(Vector3.zero, Vector3.up, 360 * RotateStart);



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.transform.RotateAround(Vector3.zero, Vector3.up, 3 * Time.deltaTime * Rotationspeed);
        
        transform.Rotate(0, 0.1f, 0);
    }
}
