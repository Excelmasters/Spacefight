using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousemovementeditor : MonoBehaviour
{
    float speed = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetAxis("Mouse X") > 0 && Input.GetKey("k"))
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                       0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        }

        else if (Input.GetAxis("Mouse X") < 0 && Input.GetKey("k"))
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                       0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        }
        if (Input.GetKey("up"))
        {
            transform.position += new Vector3(0.0f, 5 * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey("down"))
        {
            transform.position += new Vector3(0.0f, -5 * Time.deltaTime, 0.0f);
        }
    }
}

