﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLast : MonoBehaviour
{
    private int x;
    public GameObject ss;
    // Update is called once per frame
    void Update()
    {
        x = ss.transform.childCount;
        if (x != 0)
        {
            Destroy(ss.GetComponent<Transform>().GetChild(x - 1).gameObject);
        }
        enabled = false;
    }
}
