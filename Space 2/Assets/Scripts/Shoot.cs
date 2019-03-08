using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject prefab;
    private Rigidbody rb;
    private float time;

    private void Start()
    {
        if (prefab == null)
        {
            prefab = GameObject.Find("Gamemanager").GetComponent<restart>().Projectile;
        }
        time = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= 3 && Input.GetMouseButtonDown(0))
        {
            GameObject bullet = GameObject.Instantiate(prefab) as GameObject;
            // bullet.transform.position = bullet.transform.position + new Vector3(0, 0, +3);
            bullet.transform.position = transform.position + transform.up * 0.5f;
            bullet.transform.localRotation = transform.rotation;
            

            rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = transform.up * 30 + gameObject.transform.parent.GetComponent<Rigidbody>().velocity;
            
            time = 0;
        }
        
    }
}
