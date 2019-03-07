using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestShip : MonoBehaviour
{
    public Rigidbody prefabcube;
    public float time;
    public bool dest;

    private void Start()
    {
        time = 0;
        dest = false;
    }
    private void Update()
    {
        if (dest == true)
        {
            time += Time.deltaTime;
            if (time >= 10)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collideinfo)
    {
        if (collideinfo.collider.tag == "Accident")
        {

           prefabcube.isKinematic = false;
            dest = true;


        }

        if (collideinfo.collider.tag == "buildingcube")
        {
            
        }
        else
        {
         // Destroy(this.gameObject);
        }
    }
}




