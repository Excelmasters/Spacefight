using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camrotate : MonoBehaviour

{
    public GameObject ss;
    public int camspeed;
    private float xaxis = 0;
    private float yaxis = 0;
    void Start()
    {

    }


    void FixedUpdate()
    {
        if (Input.GetKey("d") && Input.GetKey("c") == false)
        {
            transform.localPosition += transform.right  * Time.deltaTime * camspeed;
        }
        if (Input.GetKey("a") && Input.GetKey("c") == false)
        {
            transform.localPosition += -transform.right * Time.deltaTime * camspeed;
        }
        if (Input.GetKey("s") && Input.GetKey("c") == false)
        {
            transform.localPosition += transform.forward * -1 * Time.deltaTime * camspeed;
        }

        if (Input.GetKey("w") && Input.GetKey("c") == false)
        {
            transform.localPosition += transform.forward * Time.deltaTime * camspeed;

        }
        if (Input.GetKey("space") && Input.GetKey("c") == false)
        {
            transform.localPosition += transform.up * Time.deltaTime * camspeed;

        }
        if (Input.GetKey("left shift") && Input.GetKey("c") == false)
        {
            transform.localPosition += -transform.up * Time.deltaTime * camspeed;

        }








        if (Input.GetMouseButton(1))
        {
            xaxis += camspeed * Input.GetAxis("Mouse X") * Time.deltaTime * 4;
            yaxis += camspeed * Input.GetAxis("Mouse Y") * Time.deltaTime * 4;
            transform.localEulerAngles = new Vector3(-yaxis, xaxis, 0f);
        }


    }
        
}