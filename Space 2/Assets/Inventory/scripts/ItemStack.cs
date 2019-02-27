using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStack    //Slot für ein einziges Item
{
    public Item item = null; //welches Item
    public int itemCount = 0; // Anzahl dieser Items   

    public ItemStack(Item newItem)
    {
        item = newItem;
    }
    public ItemStack(Item newItem, int count)
    {
        item = newItem;
        itemCount = count;
    }

    public int MaxSize
    {
        get
        {
            if (item == null)
                return 0;
            return item.maxStackSize;
        }
    }
}
