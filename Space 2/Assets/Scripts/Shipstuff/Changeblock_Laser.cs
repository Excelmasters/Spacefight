using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changeblock_Laser : MonoBehaviour
{
    GameObject gm;
    public GameObject cursor;
    public Mesh mesh_laser;

    // Update is called once per frame
    void Update()
    {
        gm = GameObject.Find("Gamemanager");
        cursor.transform.localScale = new Vector3(50, 50, 50);
        cursor.transform.eulerAngles = new Vector3(0, 180, 0);
        gm.GetComponent<Createcube>().buildingblocknumber = 2;
        cursor.GetComponent<MeshFilter>().sharedMesh = mesh_laser;
        cursor.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
        enabled = false;
    }
}
