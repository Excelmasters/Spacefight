using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestShip : MonoBehaviour
{
    public Rigidbody prefabcube;

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




