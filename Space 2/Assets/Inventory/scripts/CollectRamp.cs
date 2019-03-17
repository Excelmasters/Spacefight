using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Inventory/Item")]
public class CollectRamp : MonoBehaviour
{
    public Item item;
    public int amount;

    void OnTriggerEnter(Collider col)
    {
        InventoryHolder holder = GameObject.Find("Gamemanager").GetComponent<InventoryHolder>();
        if (holder != null)
        {
            amount = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().rampcount;
            GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().rampcount = amount + 2;
            Destroy(this.gameObject);
        }
    }
}