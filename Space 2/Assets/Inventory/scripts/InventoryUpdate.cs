using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUpdate : MonoBehaviour
{
    public int count = 19;
    public Item Blöcke;
    private InventoryHolder holder;

    private void Start()
    {
        holder = GetComponent<InventoryHolder>();
    }
    void Update()
    {
            holder.Clearblock();
            ItemStack block = new ItemStack(Blöcke, count);
            holder.AddStack(block);
    }
}
