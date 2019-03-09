using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch1 : MonoBehaviour
{
    public camfollow cf;
    public camrotate cr;
    public mousecursor mc;

    void Update()
    {
        cf.enabled = false;
        cr.enabled = true;
        mc.enabled = true;

        /*GameObject canvas = GameObject.Find("Canvas");
        for(int i = 0; i < canvas.transform.childCount; i++)
        {
            if(canvas.transform.GetChild(i).name == "Crosshair")
            {
                canvas.transform.GetChild(i).gameObject.SetActive(true);
            }
        }*/







        enabled = false;
    }
}
