using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destcube : MonoBehaviour
{

    void OnCollisionEnter(Collision collideinfo)
    {
        if (collideinfo.collider.tag == "buildingcube")
        {
            if (Input.GetMouseButton(1))
            {
                Destroy(collideinfo.rigidbody.gameObject);

            }




        }
    }
}


