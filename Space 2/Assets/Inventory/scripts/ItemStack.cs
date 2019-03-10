﻿using System.Collections;
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
    public int Id
    {
        get
        {
            if (item == null)
                return -1;

            return item.itemId;

        }
    }
    public ItemStack combine(ItemStack stack)
    {
        int combinedCount = this.itemCount + stack.itemCount;

        int diff = this.MaxSize - combinedCount;

        if (diff >= 0)
        {
            this.itemCount = combinedCount;
            return null;
        }
        this.itemCount = this.MaxSize;

        stack.itemCount -= (stack.itemCount + diff);
        return stack;
    }
}
