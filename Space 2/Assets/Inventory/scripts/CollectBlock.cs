using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Inventory/Item")]
public class CollectBlock : MonoBehaviour
{
    public Item item;
    public int amount;

    void OnTriggerEnter(Collider col)
    {
        InventoryHolder holder = GameObject.Find("Gamemanager").GetComponent<InventoryHolder>();
        if (holder != null)
        {
            amount = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().blockcount;
            GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().blockcount = amount + 5;
            Destroy(this.gameObject);
        }
    }
}
