using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezemovement : MonoBehaviour
{
    public GameObject prefab;

    void Update() => prefab.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
}
