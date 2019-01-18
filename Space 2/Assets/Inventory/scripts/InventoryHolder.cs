using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    public int width = 2; 
    public int height = 6; //Eigenschaften der Slots wie Höhe, Breite etc.

    private int numSlots;

    private ItemSlot[] slots;
    void Awake()
    {
        numSlots = width * height;
        slots = new ItemSlot[numSlots]; // Slots werden erstellt
    }

    private int GetPosition(int x, int y)
    {
        if (x < 0 || y < 0 || x >= width || y >= height)
            return -1;
        return y * width + x;
    }

    public ItemSlot GetSlot(int x, int y)
    {
        int position = GetPosition(x, y);

        if (position < 0)
        {
            Debug.LogWarning("InventoryHolder: Invalid position!");
            return null;
        }

            return slots[position];
    }

    public void SetSlot(int x, int y, ItemSlot newSlot)
    {
        int position = GetPosition(x, y);

        if (position < 0)
        {
            Debug.LogWarning("InventoryHolder: Invalid position!");
            return;
        }
        slots[position] = newSlot;
    }
}
