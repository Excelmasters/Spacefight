using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    public int width = 2; 
    public int height = 6; //Eigenschaften der Slots wie Höhe, Breite etc.

    private int numSlots;

    private ItemSlot[] slots; //Array mit dem Namen "slots"

    void Awake()
    {
        numSlots = width * height;      //Anzahl der Slots wird berechnet
        slots = new ItemSlot[numSlots]; // Slots werden erstellt
    }

    private int GetPosition(int x, int y) //Position wird gesucht
    {
        if (x < 0 || y < 0 || x >= width || y >= height) //Sicherung, dass keine falsche Angaben gemacht werden
            return -1;
        return y * width + x;
    }

    public ItemSlot GetSlot(int x, int y) //Zugriff auf bestimmte Slots
    {
        int position = GetPosition(x, y);

        if (position < 0) //ist die eingegebene Position negativ gibt es eine Fehlermeldung
        {
            Debug.LogWarning("InventoryHolder: Invalid position!");
            return null;
        }

            return slots[position]; //die Position des Slots wird ausgegeben
    }

    public void SetSlot(int x, int y, ItemSlot newSlot) // festlegen eines Slots (x, y, Name)
    {
        int position = GetPosition(x, y); //position wird abgefragt

        if (position < 0) //wenn die position negativ ist wird eine Fehlermeldung ausgegeben
        {
            Debug.LogWarning("InventoryHolder: Invalid position!");
            return;
        }
        slots[position] = newSlot; //ist alles korrekt wird dieser Slot erstellt
    }
}
