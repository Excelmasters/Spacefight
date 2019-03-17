using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Grundlage des Inventars: https://docs.unity3d.com/ScriptReference/GUI.Window.html
[AddComponentMenu("Inventory/OnGUI")] //unter Reiter Component Inventory OnGUI um dieses zu ändern
[RequireComponent(typeof(InventoryHolder))] //wir brauchen einen InventoryHolder dafür dieser muss erstellt werden

public class InventoryOnGUI : MonoBehaviour
{
    public int WindowId = 1;
    public string windowTitle = "Inventory";

    public static int BOX_WIDTH = 35; //Größe der Kasten
    public static int BOX_HEIGHT = 35;
    public static int ABSTAND_TOP = 30;// Entfernung vom oberen Rand
    public static int ABSTAND_SIDES = 10;// Entfernung von der Seite

    private InventoryHolder holder;

    private Rect windowPosition;
    private bool open = false;
    void Start()
    {
        holder = GetComponent<InventoryHolder>(); //überprüft ob auf diesem Gameobject GUI ein InventoryHolder vorhanden ist 
        if (holder == null)
        {
            Debug.LogError("Bitte geben sie einen InventoryHolder zu folgendem Objekt hinzu:" + this.gameObject.name); //Fehlermeldung wenn kein InventoryHolder vorhanden ist
        }

        CalcPosition(); //Position wird berechnet

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // E drücken um das Inventar zu öffnen
        {
            open = !open;
        }
    }

    void OnGUI()
    {
        if (open)
            GUI.Window(WindowId, windowPosition, InventoryWindow, windowTitle);    //Attribute des Fensters
    }
    void InventoryWindow(int id)
    {
        for (int i = 0; i < holder.height; i++) // einzelnen Slots werden erstellt und wenn in diesen ein Itemstack vorhanden ist diese angezeigt
        {
            for (int j = 0; j < holder.width; j++) 
            {
                Texture2D icon = null;
                ItemStack itemStack = holder.GetStack(j, i);

                if (itemStack != null && itemStack.item != null) 
                {
                    icon = itemStack.item.itemIcon;
                }
                GUI.Box(new Rect(j * BOX_WIDTH + ABSTAND_SIDES, i * BOX_HEIGHT + ABSTAND_TOP, BOX_WIDTH, BOX_HEIGHT), icon); 

                if (icon != null)
                    GUI.Label(new Rect(j * BOX_WIDTH + ABSTAND_SIDES + 5, i * BOX_HEIGHT + ABSTAND_TOP + 2, BOX_WIDTH, BOX_HEIGHT), itemStack.itemCount.ToString());
            }
        }
    }
    void CalcPosition() //Funktion um Position des Inventars zu berechnen
    {
        int width = holder.width * BOX_WIDTH + ABSTAND_SIDES * 2;
        int height = holder.height * BOX_HEIGHT + ABSTAND_TOP * 2;

        windowPosition = new Rect(Screen.width / 2 - 600, Screen.height / 2 - 300, width, height);
    }
}

