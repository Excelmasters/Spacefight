using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Inventory/Holder")]
public class InventoryHolder : MonoBehaviour
{
    public int width = 2; 
    public int height = 6; //Eigenschaften der Stacks wie Höhe, Breite etc.

    private int numStacks;

    private ItemStack[] stacks; //Array mit dem Namen "stacks"

    void Awake()
    {
        numStacks = width * height;      //Anzahl der Stacks wird berechnet
        stacks = new ItemStack[numStacks]; // Stacks werden erstellt
                                           //ItemStacks stack1 = new ItemStack();//Bsp Stack mit Name "stack1"
    }

    private int GetPosition(int x, int y) //Position wird gesucht
    {
        if (x < 0 || y < 0 || x >= width || y >= height) //Sicherung, dass keine falsche Angaben gemacht werden
            return -1;
        return y * width + x;
    }

    public ItemStack GetStack(int x, int y) //Zugriff auf bestimmte Stacks
    {
        int position = GetPosition(x, y);

        if (position < 0) //ist die eingegebene Position negativ gibt es eine Fehlermeldung
        {
            Debug.LogWarning("InventoryHolder: Invalid position!");
            return null;
        }

            return stacks[position]; //die Position des Stacks wird ausgegeben
    }

    public void SetStack(int x, int y, ItemStack newStack) // festlegen eines Stacks (x, y, Name)
    {
        int position = GetPosition(x, y); //position wird abgefragt

        if (position < 0) //wenn die position negativ ist wird eine Fehlermeldung ausgegeben
        {
            Debug.LogWarning("InventoryHolder: Invalid position!");
            return;
        }
        stacks[position] = newStack; //ist alles korrekt wird dieser Stack erstellt
    }
    public void AddStack(ItemStack stack)
    {
        for (int i = 0; i < numStacks; i++)
        {

        }
    }

    public void ClearInventory()
    {
        for(int i = 0; i < numStacks; i++)
        {
            stacks[i] = null;
            
        }
    }
}
