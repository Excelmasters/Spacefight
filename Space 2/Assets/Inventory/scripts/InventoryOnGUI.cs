using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Inventory/OnGUI")] //unter Reiter Component Inventory OnGUI um dieses zu ändern
[RequireComponent(typeof(InventoryHolder))] //wir brauchen einen InventoryHolder dafür dieser muss erstellt werden

public class InventoryOnGUI : MonoBehaviour
{
    public int WindowId = 1;
    public string windowTitle = "Inventory";

    public static int BOX_WIDTH = 35; //Größe der Kasten
    public static int BOX_HEIGHT = 35;
    public static int OFFSET_TOP = 30;// Entfernung vom oberen Rand
    public static int OFFSET_SIDES = 10;// Entfernung von der Seite

    private InventoryHolder holder;

    private Rect windowPosition;
    private bool isOpen = false;
    void Start()
    {
        holder = GetComponent<InventoryHolder>(); //überprüft ob auf diesem Gameobject GUI ein InventoryHolder vorhanden ist 
        if (holder == null)
        {
            Debug.LogError("Please add a IventoryHolder to" + this.gameObject.name); //Fehlermeldung wenn kein InventoryHolder vorhanden ist
        }

        CalcPosition(); //Position wird berechnet

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            holder.ClearInventory();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;
        }
    }

    void OnGUI()
    {
        if (isOpen)
            GUI.Window(WindowId, windowPosition, InventoryWindow, windowTitle);    //neuer Bereich wird erstellt & Attribute festegelegt
    }
    void InventoryWindow(int id)
    {
        for (int i = 0; i < holder.height; i++) // wieviele Slots vertikal gebraucht werden
        {
            for (int j = 0; j < holder.width; j++) // wieviele Slots waagerecht gebraucht werden
            {
                Texture2D icon = null;
                ItemStack itemStack = holder.GetStack(j, i);

                if (itemStack != null && itemStack.item != null) //überprüft ob Item in diesem Slot enthalten ist
                {
                    icon = itemStack.item.itemIcon;
                }
                GUI.Box(new Rect(j * BOX_WIDTH + OFFSET_SIDES, i * BOX_HEIGHT + OFFSET_TOP, BOX_WIDTH, BOX_HEIGHT), icon); //Größe des Inventars

                if (icon != null)
                    GUI.Label(new Rect(j * BOX_WIDTH + OFFSET_SIDES + 5, i * BOX_HEIGHT + OFFSET_TOP + 2, BOX_WIDTH, BOX_HEIGHT), itemStack.itemCount.ToString());
            }
        }
    }
    void CalcPosition() //Funktion um Position zu berechnen
    {
        int width = holder.width * BOX_WIDTH + OFFSET_SIDES * 2;
        int height = holder.height * BOX_HEIGHT + OFFSET_TOP * 2;

        windowPosition = new Rect(Screen.width / 2 - 600, Screen.height / 2 - 300, width, height);
    }
}

