using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBlock : MonoBehaviour
{
    public int times;
    private InventoryHolder holder;

    private void Start()
    {
        holder = GetComponent<InventoryHolder>();
    }
    void Update()
    {
        times = GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().count;
        times = times + 1;
        GameObject.Find("Gamemanager").GetComponent<InventoryUpdate>().count = times;
        enabled = false;
    }
}
