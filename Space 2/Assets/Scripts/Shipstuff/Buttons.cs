using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private bool isenabled;
    public GameObject ufo;
    public GameObject SolarSystem;
    private int run = 0;
    public void Start()
    {
        ufo = GameObject.Find("Gamemanager").GetComponent<restart>().UFO;
        SolarSystem = GameObject.Find("SolarSystem");
        isenabled = false;
        run = 0;
    }

    private void SpawnEnemys()
    {
        GameObject UFO = GameObject.Instantiate(ufo) as GameObject;
        UFO.transform.SetParent(SolarSystem.transform);
        UFO.name = ("UFO");
        UFO.transform.position = transform.parent.transform.position;
        UFO.GetComponent<Rigidbody>().isKinematic = true;
        UFO.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);



       
    }
    private void DeleteEnemys()
    {
        int childnum = SolarSystem.transform.childCount;
        for (int i = 0; i < childnum; i++)
        {
            if (SolarSystem.transform.GetChild(i).name == "UFO")
            {
                Destroy(SolarSystem.transform.GetChild(i).gameObject);
            }

        }






        return;
    }



    private void OnMouseDown()
    {
        if (isenabled == false)
        {
            Debug.Log("Loop");

            isenabled = true;
            int childnum = SolarSystem.transform.childCount;
            for (int i = 0; i < childnum; i++)
            {
                if (SolarSystem.transform.GetChild(i).name == "Planet")
                {
                    SolarSystem.transform.GetChild(i).GetComponent<RotateEarth>().enabled = false;
                    SolarSystem.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
                }

            }
            this.transform.gameObject.SetActive(true);

            GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(false);
            SpawnEnemys();
            return;

        }
        if(isenabled == true ) 
        {
            isenabled = false;
            GameObject SolarSystem = GameObject.Find("SolarSystem");
            int childnum = SolarSystem.transform.childCount;
            for (int i = 0; i < childnum; i++)
            {
                if (SolarSystem.transform.GetChild(i).name == "Planet")
                {
                    SolarSystem.transform.GetChild(i).GetComponent<RotateEarth>().enabled = true;
                    SolarSystem.transform.GetChild(i).GetChild(1).gameObject.SetActive(true);
                }
                
            }
            this.transform.gameObject.SetActive(true);
            
            GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
            DeleteEnemys();
            return;
        }
        
    }
}
