using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLast : MonoBehaviour
{
    private int x;
    public GameObject ss;
    private int bc;
    private int lc;
    private int rc;
    private int bn;
    private InventoryHolder holder;
    // Update is called once per frame
    void Update()
    {
        holder = GetComponent<InventoryHolder>();
        bn = GameObject.Find("Gamemanager").GetComponent<Createcube>().buildingblocknumber;
        bc = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().blockcount;
        rc = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().rampcount;
        lc = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().lasercount;

        if (lc != 0 & bn != 2 | bc != 0 & bn != 0 | rc != 0 & bn != 1)
        {


            x = ss.transform.childCount;
            if (x > 1)
            {
                Destroy(ss.GetComponent<Transform>().GetChild(x - 1).gameObject);
            }

            enabled = false;
        }
    }
}
