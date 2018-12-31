using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toff_build : MonoBehaviour
{
    public GameObject build;
    public GameObject cube;
    public GameObject ramp;

    // Update is called once per frame
    void Update()
    {
        build.SetActive(false);
        cube.SetActive(true);
        ramp.SetActive(true);
        enabled = false;
    }
}
