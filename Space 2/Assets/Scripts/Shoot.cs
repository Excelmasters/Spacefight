using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject prefab;
    private Rigidbody rb;

    private void Start()
    {
        if (prefab == null)
        {
            prefab = GameObject.Find("Gamemanager").GetComponent<restart>().Projectile;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("o"))
        {
            GameObject bullet = GameObject.Instantiate(prefab) as GameObject;
            bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
            rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 5, 0);
        }
        
    }
}
