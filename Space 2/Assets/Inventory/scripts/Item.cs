using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public int itemId = -1;
    public string itemName;
    public Texture2D itemIcon; //Angaben der Eigenschaften
    public int maxStackSize = 100;
    public GameObject item;
}
