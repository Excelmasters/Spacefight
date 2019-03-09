﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;



public class Createcube : MonoBehaviour
{
    public GameObject cursor;
    public GameObject ss;
    public GameObject[] buildingblocks;
    public int buildingblocknumber = 0;

    void Update()
    {
        cursor.GetComponent<Rigidbody>().freezeRotation = false;
        if (Input.GetMouseButtonDown(0) & Input.GetKey("q") == false)
        {

            GameObject cube = Object.Instantiate(buildingblocks[buildingblocknumber]) as GameObject;
            cube.transform.position = cursor.transform.position;
            cube.transform.rotation = cursor.transform.rotation;
            if (buildingblocknumber == 2)
            {
                cube.transform.rotation = cube.transform.rotation * Quaternion.Euler(90, 0, 0);
            }
            cube.transform.parent = ss.transform;
        }
        if (Input.GetMouseButton(0) & Input.GetKey("q"))
        {

            GameObject cube = Object.Instantiate(buildingblocks[buildingblocknumber]) as GameObject;
            cube.transform.position = cursor.transform.position;           
            cube.transform.parent = ss.transform;
        }


        if (Input.GetKeyDown("d") && Input.GetKey("c"))
        {
            cursor.transform.Rotate(0, 90, 0);
        }
        if (Input.GetKeyDown("a") && Input.GetKey("c"))
        {
            cursor.transform.Rotate(0, -90, 0);
        }
        if (Input.GetKeyDown("w") && Input.GetKey("c"))
        {
            cursor.transform.Rotate(90, 0, 0);
        }
        if (Input.GetKeyDown("s") && Input.GetKey("c"))
        {
            cursor.transform.Rotate(-90, 0, 0);
        }

    }

}
