using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour
{
    public GameObject ss;
    public Material spherematerial;
    public GameObject prefab;
    public GameObject Projectile;


    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in ss.transform)
        {
            Destroy(child.gameObject);
        }
        ss.transform.position = new Vector3(0, 0, 0);
        ss.transform.eulerAngles = new Vector3(0, 0, 0);
        ss.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        ss.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        enabled = false;
    }
}
