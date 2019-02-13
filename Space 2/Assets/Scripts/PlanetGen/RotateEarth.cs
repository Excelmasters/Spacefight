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
        rb.transform.RotateAround(this.transform.parent.transform.position, Vector3.up, 360 * RotateStart);
    


        Rotationspeed = (Time.deltaTime * 100000000 / (transform.localPosition.magnitude * transform.localPosition.magnitude * 1000)     )* transform.GetComponentInParent<MakeSolarSystem>().Rotationspeed;



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.transform.RotateAround(Vector3.zero, Vector3.up, Rotationspeed);
        
        transform.Rotate(0, 0.1f, 0);
    }
}
