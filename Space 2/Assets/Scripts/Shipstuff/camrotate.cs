using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camrotate : MonoBehaviour

{
    public GameObject ss;
    public int camspeed;
    void Start()
    {

    }


    void FixedUpdate()
    {
        transform.LookAt(ss.transform);
        if (Input.GetKey("a")  && Input.GetKey("left shift") == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime * camspeed);
        }
        if (Input.GetKey("d") && Input.GetKey("left shift") == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * camspeed);
        }
        if (Input.GetKey("w") && Input.GetKey("left shift") == false)
        {
            transform.Translate(Vector3.up * Time.deltaTime * camspeed);
        }
        if (Input.GetKey("s") && Input.GetKey("left shift") == false)
        {
            transform.Translate(Vector3.down * Time.deltaTime * camspeed);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            this.transform.position = this.transform.position + new Vector3(0, 0, -3); 
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            this.transform.position = this.transform.position + new Vector3(0, 0, 3);
        }


    }
}