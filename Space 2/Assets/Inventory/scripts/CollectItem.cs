using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Inventory/Item")]
public class CollectItem : MonoBehaviour
{
    public Item item;
    public int amount;

    void OnTriggerEnter(Collider col)
    {
        InventoryHolder holder = col.GetComponent<InventoryHolder>();
        if (holder != null)
        {
            ItemStack addItemStack = new ItemStack(item, amount);
            addItemStack = holder.AddStack(addItemStack);

            if (addItemStack == null)
                Destroy(this.gameObject);
            else
            {
                amount = addItemStack.itemCount;
            }
        }
    }
}
