using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toff_build : MonoBehaviour
{
    public GameObject build;
    public GameObject cube;
    public GameObject Gamemanager;
    public GameObject ramp;
    public GameObject canvas;
  //  public GameObject Canvas;

    void Update()
    {
        canvas.GetComponent<Ton_build>().enabled = false;
        build.SetActive(false);
        cube.SetActive(true);
        ramp.SetActive(true);

        enabled = false;


    }
}
