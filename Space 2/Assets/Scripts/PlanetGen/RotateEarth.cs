using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEarth : MonoBehaviour
{
    private Rigidbody rb;
    public float Rotationspeed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        float RotateStart = Random.Range(0f, 1f);
        rb.transform.RotateAround(Vector3.zero, Vector3.up, 360 * RotateStart);
    


        Rotationspeed = Time.deltaTime * 10000000000f / (transform.position.magnitude * 100 * transform.position.magnitude * 100)        * transform.GetComponentInParent<MakeSolarSystem>().Rotationspeed;



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.transform.RotateAround(Vector3.zero, Vector3.up, Rotationspeed);
        
        transform.Rotate(0, 0.1f, 0);
    }
}
