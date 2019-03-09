using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changeblock_cube : MonoBehaviour
{
    GameObject gm;
    public GameObject cursor;
    public Mesh mesh_cube;

    // Update is called once per frame
    void Update()
    {
        gm = GameObject.Find("Gamemanager");
        cursor.transform.localScale = new Vector3(1, 1, 1);
        gm.GetComponent<Createcube>().buildingblocknumber = 0;
        cursor.GetComponent<MeshFilter>().sharedMesh = mesh_cube;
        cursor.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        enabled = false;
    }
}
