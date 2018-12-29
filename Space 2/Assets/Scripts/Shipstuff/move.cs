using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public int speed ;
    public bool fixedspeed;
    private int factor = 1;
    void FixedUpdate()
    {
        if (fixedspeed == true)
        {
            if (Input.GetKey("w")) { this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 1 * speed *Time.deltaTime); }
            if (Input.GetKey("s")) { this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -1 * speed * Time.deltaTime); }
            if (Input.GetKey("a")) { this.GetComponent<Rigidbody>().velocity = new Vector3(-1 * speed * Time.deltaTime, 0, 0); }
            if (Input.GetKey("d")) { this.GetComponent<Rigidbody>().velocity = new Vector3(1 * speed * Time.deltaTime, 0, 0); }
            if (Input.GetKey("space")) { this.GetComponent<Rigidbody>().velocity = new Vector3(0, 1 * speed * Time.deltaTime, 0); }
            if (Input.GetKey("left shift")) { this.GetComponent<Rigidbody>().velocity = new Vector3(0, -1 * speed * Time.deltaTime, 0); }
        }
        if (fixedspeed == false)
        { 
            if (Input.GetKey("w")) { this.GetComponent<Rigidbody>().AddForce(0, 0, 1 * speed * Time.deltaTime * factor); }
            if (Input.GetKey("s")) { this.GetComponent<Rigidbody>().AddForce(0, 0, -1 * speed * Time.deltaTime * factor); }
            if (Input.GetKey("a")) { this.GetComponent<Rigidbody>().AddForce(-1 * speed * Time.deltaTime * factor, 0, 0); }
            if (Input.GetKey("d")) { this.GetComponent<Rigidbody>().AddForce(1 * speed * Time.deltaTime * factor, 0, 0); }
            if (Input.GetKey("space")) { this.GetComponent<Rigidbody>().AddForce(0, 1 * speed * Time.deltaTime * factor, 0); }
            if (Input.GetKey("left shift")) { this.GetComponent<Rigidbody>().AddForce(0, -1 * speed * Time.deltaTime * factor, 0); }
        }
    }
    
}
