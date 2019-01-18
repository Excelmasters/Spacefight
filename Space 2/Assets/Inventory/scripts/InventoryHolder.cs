using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    public int width = 2; 
    public int height = 6; //Eigenschaften der Slots wie Höhe, Breite etc.
    private int numSlots;
    public ItemSlot[] slots;
    void Awake()
    {
        numSlots = width * height;
        slots = new ItemSlot[numSlots]; // Slots werden erstellt
        foreach (ItemSlot slot in slots)
            Debug.Log(slot);
    }
}
