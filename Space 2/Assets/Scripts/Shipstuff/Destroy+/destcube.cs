using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destcube : MonoBehaviour
{
    public int bn;
    public int blockcount;
    public int rampcount;
    public int lasercount;

    void OnCollisionEnter(Collision collideinfo)
    {
        if (collideinfo.collider.tag == "buildingcube")
        {
           
            if (Input.GetMouseButton(1))
            {
                bn = GameObject.Find("Gamemanager").GetComponent<Createcube>().buildingblocknumber;
                Debug.Log("Hallo");
                Destroy(collideinfo.rigidbody.gameObject);
       
            }




        }
    }
}


