using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBlock : MonoBehaviour
{
    public int blockcount;
    public int lasercount;
    public int rampcount;
    private InventoryHolder holder;
    public int bn;

    private void Start()
    {
        holder = GetComponent<InventoryHolder>();
    }
    void Update()
    {
        blockcount = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().blockcount;
        lasercount = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().lasercount;
        rampcount = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().rampcount;

        bn = GameObject.Find("Gamemanager").GetComponent<Createcube>().buildingblocknumber;
        if (bn == 0)
        {
            blockcount = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().blockcount;
            GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().blockcount = blockcount + 1;
        }
        if (bn == 2)
        {
            lasercount = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().lasercount;
            GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().lasercount = lasercount + 1;
        }
        if (bn == 1)
        {
            rampcount = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().rampcount;
            GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().rampcount = rampcount + 1;
        }
            enabled = false;
    }
}
