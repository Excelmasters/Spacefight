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
        stacks = new ItemStack[numStacks]; // größe des arrays wird bestimmt

    }

    private int GetPosition(int x, int y) //Position wird gesucht
    {
        if (x < 0 || y < 0 || x >= width || y >= height) //Sicherung, dass keine falsche Angaben gemacht werden
            return -1;
        return y * width + x;
    }

    public ItemStack GetStack(int x, int y) //Zugriff auf Stack an dieser Position
    {
        int position = GetPosition(x, y);

        if (position < 0) //ist die eingegebene Position negativ gibt es eine Fehlermeldung
        {
            Debug.LogWarning("InventoryHolder: Invalid position!");
            return null;
        }

        return stacks[position]; // zugegriffene Stack wird zurück gegeben
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
    public ItemStack AddStack(ItemStack newStack) //Funktion zum hinzufügen von Stacks
    {
        ItemStack stack = newStack;
        for (int i = 0; i < numStacks; i++)//geht alle Stacks durch und sucht ob ein Stack schon vorhanden ist werden diese items hinzugefügt 
        {
            if (stacks[i] != null && stacks[i].Id == stack.Id) // wenn gleiche Stacks vorhanden sind werden sie mit der combine Funktion verbunden
            {
                stack = stacks[i].combine(stack);
                if (stack == null)
                    break;
            }
        }
        if (stack != null) 
        {
            if (stack.itemCount <= 0)
                stack = null;

            for (int i = 0; i < numStacks; i++)
            {
                if (stacks[i] == null)
                {
                    stacks[i] = stack;
                    if (stack.itemCount > stack.MaxSize) // wenn das Stack mehr Items enthält, dann wird hierdurch ein neues Stack erstellt
                    {
                        int oversize = stack.itemCount - stack.MaxSize;
                        stack.itemCount = stack.MaxSize;
                        stack = new ItemStack(stack.item, oversize);
                    }
                    else
                    {
                        stack = null;
                    }
                    stack = null;
                    break;
                }
            }
        }
        return stack;
    }

    public void Clearblock() // nur die Blöcke im Inventar werden gelöscht
    {
        stacks[0] = null;
    }

    public void Clearlaser() // nur die Laser werden gelöscht
    {
        stacks[2] = null;
    }

    public void Clearramp() // nur die Rampen werden gelöscht
    {
        stacks[1] = null;
    }
}
