using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;



public class Createcube : MonoBehaviour
{
    public GameObject prefab;
    private int positionx = 0;
    private int positiony = 0;
    private int positionz = 0;
    public GameObject cursor;
    public GameObject ss;
    private int sol = 1;

    void deletemesh()
    {

    }
    void Update()
    {
        cursor.GetComponent<Rigidbody>().freezeRotation = true;
        if (Input.GetMouseButtonDown(0) & Input.GetKey("q") == false)
        {

                GameObject cube = Object.Instantiate(prefab) as GameObject;
            cube.transform.position = cursor.transform.position;
            cube.transform.parent = ss.transform;
        }
        if (Input.GetMouseButton(0) & Input.GetKey("q"))
        {

            GameObject cube = Object.Instantiate(prefab) as GameObject;
            cube.transform.position = cursor.transform.position;
            cube.transform.parent = ss.transform;

        }


        if (Input.GetMouseButtonDown(1))
        {
            deletemesh();
        }




        if (Input.GetKeyDown("a"))
        {
            positionx = positionx - 1 * sol;
        }
        if (Input.GetKeyDown("d"))
        {
            positionx = positionx + 1 * sol;

        }
        if (Input.GetKeyDown("s"))
        {
            positionz = positionz - 1 * sol;
        }
        if (Input.GetKeyDown("w"))
        {
            positionz = positionz + 1 * sol;

        }
        if (Input.GetKeyDown("left shift"))
        {
            positiony = positiony - 1 * sol;
        }
        if (Input.GetKeyDown("space"))
        {
            positiony = positiony + 1 * sol;

        }


        if (Input.GetMouseButtonDown(2) == true)
        {
            cursor.GetComponent<Renderer>().enabled = false;
            enabled = false;

        }
    }

}
