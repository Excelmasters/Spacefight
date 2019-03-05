using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlanet : MonoBehaviour
{
    private void Update()
    {
        transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), 10);
    }

}

