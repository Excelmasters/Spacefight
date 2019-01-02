using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;



public class Createcube : MonoBehaviour
{
    public GameObject prefabcube;
    public GameObject ramp;
    public GameObject cursor;
    public GameObject ss;
    public GameObject[] buildingblocks;
    public int x = 0;

    void Update()
    {
        cursor.GetComponent<Rigidbody>().freezeRotation = true;
        if (Input.GetMouseButtonDown(0) & Input.GetKey("q") == false)
        {

                GameObject cube = Object.Instantiate(buildingblocks[x]) as GameObject;
            cube.transform.position = cursor.transform.position;
            cube.transform.parent = ss.transform;
        }
        if (Input.GetMouseButton(0) & Input.GetKey("q"))
        {

            GameObject cube = Object.Instantiate(buildingblocks[x]) as GameObject;
            cube.transform.position = cursor.transform.position;
            cube.transform.parent = ss.transform;

        }
















        if (Input.GetMouseButtonDown(2) == true)
        {
            cursor.GetComponent<Renderer>().enabled = false;
            enabled = false;

        }
    }

}
