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
        enabled = false;
    }
}
