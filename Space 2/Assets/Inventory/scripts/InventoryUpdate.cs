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
    public int buildingblocknumber;

    private void Start()
    {
        blockcount = 9;
        lasercount = 1;
        rampcount = 9;

        holder = GetComponent<InventoryHolder>();

        ItemStack block = new ItemStack(Blöcke, 9);
        holder.AddStack(block);

        ItemStack laser = new ItemStack(Laser, 1);
        holder.AddStack(laser);

        ItemStack ramps = new ItemStack(Rampen, 9);
        holder.AddStack(ramps);
    }
    void Update()
    {

            holder.Clearblock();
            ItemStack block = new ItemStack(Blöcke, blockcount);
            holder.AddStack(block);

   

        
            holder.Clearlaser();
            ItemStack laser = new ItemStack(Laser, lasercount);
            holder.AddStack(laser);
        


  
            holder.Clearramp();
            ItemStack ramps = new ItemStack(Rampen, rampcount);
            holder.AddStack(ramps);
    
    }
}
