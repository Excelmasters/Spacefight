using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toff_build : MonoBehaviour
{
    public GameObject build;

    // Update is called once per frame
    void Update()
    {
        build.SetActive(false);
        enabled = false;
    }
}
