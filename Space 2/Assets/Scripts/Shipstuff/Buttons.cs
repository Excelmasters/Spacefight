using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private bool isenabled = false;

    private void SpawnEnemys()
    {
        //Spawn the enemys here
        return;
    }
    private void DeleteEnemys()
    {
        //delete Existing enemys here
        return;
    }



    private void OnMouseDown()
    {
        if (isenabled == false)
        {
            GameObject SolarSystem = GameObject.Find("SolarSystem");
            int childnum = SolarSystem.transform.childCount;
            for (int i = 0; i < childnum; i++)
            {
                if (SolarSystem.transform.GetChild(i).name == "Planet")
                {
                    SolarSystem.transform.GetChild(i).GetComponent<RotateEarth>().enabled = false;
                    SolarSystem.transform.GetChild(i).GetChild(1).gameObject.active = false;
                    //Destroy(SolarSystem.transform.GetChild(i).gameObject);
                }

            }
            this.transform.gameObject.active = true;
            Debug.Log("Aus");
            isenabled = true;
            GameObject.Find("Canvas").transform.GetChild(0).gameObject.active = false;
            SpawnEnemys();
            return;
        }

        if (isenabled == true)
        {
            GameObject SolarSystem = GameObject.Find("SolarSystem");
            int childnum = SolarSystem.transform.childCount;
            for (int i = 0; i < childnum; i++)
            {
                if (SolarSystem.transform.GetChild(i).name == "Planet")
                {
                    SolarSystem.transform.GetChild(i).GetComponent<RotateEarth>().enabled = true;
                    SolarSystem.transform.GetChild(i).GetChild(1).gameObject.active = true;
                    //Destroy(SolarSystem.transform.GetChild(i).gameObject);
                }

            }
            this.transform.gameObject.active = true;
            Debug.Log("Aus");
            isenabled = false;
            GameObject.Find("Canvas").transform.GetChild(0).gameObject.active = true;
            DeleteEnemys();
            return;
        }

    }
}
