using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollow : MonoBehaviour

{
    public Vector3 offset;
    public GameObject ss;
    public camrotate cr;
    public mousecursor mc;
    public GameObject cursor;


    void FixedUpdate()
    {
        if (ss.gameObject != null)
        {
            transform.position = ss.transform.position + offset;
            transform.LookAt(ss.transform);
        }

        if(Input.GetKey("c") && Input.GetKey(KeyCode.DownArrow))
        {
            offset.z = offset.z - 0.1f;
        }
        if (Input.GetKey("c") && Input.GetKey(KeyCode.UpArrow))
        {
            offset.z = offset.z + 0.1f;
        }
        if (Input.GetKey("c") && Input.GetKey(KeyCode.LeftArrow))
        {
            offset.y = offset.y - 0.1f;
        }
        if (Input.GetKey("c") && Input.GetKey(KeyCode.RightArrow))
        {
            offset.y = offset.y + 0.1f;
        }











        //this.transform.eulerAngles = new Vector3(0, 0, 0);
        cr.enabled = false;
        mc.enabled = false;
        cursor.GetComponent<MeshRenderer>().enabled = false;
    }
  



}
