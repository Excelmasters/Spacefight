using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Inventory/Item")]
public class CollectLaser : MonoBehaviour
{
    public Item item;
    public int amount;

    void OnTriggerEnter(Collider col)
    {
        InventoryHolder holder = GameObject.Find("Gamemanager").GetComponent<InventoryHolder>();
        if (holder != null)
        {
            amount = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().lasercount;
            GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().lasercount = amount + 1;
            Destroy(this.gameObject);
        }
    }
}