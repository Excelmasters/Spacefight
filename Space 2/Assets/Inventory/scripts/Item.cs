using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public int itemId = -1;
    public string itemName;
    public Texture2D itemIcon; //Angaben der Eigenschaften

    [Space(5f)]
    public int maxStackSize = 100;

    [Space(10f)]
    public GameObject item;
}
