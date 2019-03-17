using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUpdate : MonoBehaviour
{
    public int blockcount;
    public int lasercount;
    public int rampcount;
    public Item Blöcke;
    public Item Laser;
    public Item Rampen;
    private InventoryHolder holder;
    public int bn;

    private void Start()
    {
        blockcount = 10;
        lasercount = 1;
        rampcount = 10;

        holder = GetComponent<InventoryHolder>();

        ItemStack block = new ItemStack(Blöcke, 10);
        holder.AddStack(block);

        ItemStack ramps = new ItemStack(Rampen, 10);
        holder.AddStack(ramps);

        ItemStack laser = new ItemStack(Laser, 1);
        holder.AddStack(laser);

 


    }
    void Update()
    {
        if (blockcount != 0)
        {
            holder.Clearblock();
            ItemStack block = new ItemStack(Blöcke, blockcount);
            holder.AddStack(block);
        }
        else
        {
            holder.Clearblock();
        }


        if (lasercount != 0)
        {
            holder.Clearlaser();
            ItemStack laser = new ItemStack(Laser, lasercount);
            holder.AddStack(laser);
        }
        else
        {
            holder.Clearlaser();
        }


        if (rampcount != 0)
        {
            holder.Clearramp();
            ItemStack ramps = new ItemStack(Rampen, rampcount);
            holder.AddStack(ramps);
        }
        else
        {
            holder.Clearramp();
        }

    }
}
