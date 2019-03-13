using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBlock : MonoBehaviour
{
    public int blockcount;
    public int lasercount;
    public int rampcount;
    private InventoryHolder holder;
    public int buildingblocknumber = 0;

    private void Start()
    {
        holder = GetComponent<InventoryHolder>();
    }
    void Update()
    {

            blockcount = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().blockcount;
            GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().blockcount = blockcount + 1;

            lasercount = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().lasercount;
            GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().lasercount = lasercount + 1;

            rampcount = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().rampcount;
            GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().rampcount = rampcount + 1;

            enabled = false;
    }
}
