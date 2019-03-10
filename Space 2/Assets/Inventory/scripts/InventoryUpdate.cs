using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUpdate : MonoBehaviour
{
    public int count = 19;
    public Item Blöcke;
    public Item Laser;
    public Item Raketen;
    private InventoryHolder holder;

    private void Start()
    {
        holder = GetComponent<InventoryHolder>();

        ItemStack block = new ItemStack(Blöcke, 20);
        holder.AddStack(block);

        ItemStack laser = new ItemStack(Laser, 1);
        holder.AddStack(laser);

        ItemStack rockets = new ItemStack(Raketen, 1);
        holder.AddStack(rockets);
    }
    void Update()
    {
        holder.Clearblock();
        ItemStack block = new ItemStack(Blöcke, count);
        holder.AddStack(block);
    }
}
