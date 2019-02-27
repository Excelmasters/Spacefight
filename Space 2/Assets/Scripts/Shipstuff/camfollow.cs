using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollow : MonoBehaviour

{
    public int height;
    public int dist;
    public GameObject ss;
    public camrotate cr;
    public mousecursor mc;
    public GameObject cursor;


    void Update()
    {
        this.transform.position = ss.transform.position + new Vector3(0, height, dist);
        this.transform.eulerAngles = new Vector3(0, 0, 0);
        cr.enabled = false;
        mc.enabled = false;
        cursor.GetComponent<MeshRenderer>().enabled = false;
    }
  



}
