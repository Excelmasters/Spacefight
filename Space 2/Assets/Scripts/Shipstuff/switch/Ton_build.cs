using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ton_build : MonoBehaviour
{
    public GameObject build;
    public GameObject cube;
    public GameObject ramp;
    public GameObject Gamemanager;
    public GameObject laser;


    void Update()
    {
        build.SetActive(true);
        cube.SetActive(false);
        ramp.SetActive(false);
        laser.SetActive(false);
        Gamemanager.GetComponent<Createcube>().enabled = false;
        //  Gamemanager.GetComponent<Createramp>().enabled = false;


       /* GameObject canvas = GameObject.Find("Canvas");
        for (int i = 0; i < canvas.transform.childCount; i++)
        {
            if (canvas.transform.GetChild(i).name == "Crosshair")
            {
                canvas.transform.GetChild(i).gameObject.SetActive(false);
            }
        }*/

        enabled = false;
    }
}
