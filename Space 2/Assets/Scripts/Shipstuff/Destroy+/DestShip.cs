using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestShip : MonoBehaviour
{
    public Rigidbody prefabcube;
    public float time; 

    private void Start()
    {
        time = 0;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(time >= 10)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collideinfo)
    {
        if (collideinfo.collider.tag == "Accident")
        {

           prefabcube.isKinematic = false;



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




