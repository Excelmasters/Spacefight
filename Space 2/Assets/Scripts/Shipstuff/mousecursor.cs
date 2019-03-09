using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousecursor : MonoBehaviour
{
    RaycastHit hit;
    public Camera cam;
    public GameObject cursor;
    private int facx = 1;
    private int facy = 1;
    private int facz = 1;
    private int ssx = 1;
    public GameObject ss;
    private Vector3 posi;
    public Texture texture;


    void Update()

    {
        
        StopShip();


   


        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "buildingcube" || hit.collider.gameObject.tag == "Core")
            {
                cursor.GetComponent<MeshRenderer>().enabled = true;
                if (Input.GetMouseButtonDown(1) && hit.collider.gameObject.tag == "buildingcube")
                {
                    Destroy(hit.collider.gameObject);
                }
                posi = hit.point + hit.normal *0.5f; 
           
                if (hit.point.x < 0)
                {
                    facx = -1;
                }
                else
                {
                    facx = 1;
                }
                if (hit.point.y < 0)
                {
                    facy = -1;
                }
                else
                {
                    facy = 1;
                }
                if (hit.point.z < 0)
                {
                    facz = -1;
                }
                else
                {
                    facz = 1;
                }

                cursor.transform.position = new Vector3((int)(posi.x + 0.50f * facx), (int)(posi.y + 0.50f * facy), (int)(posi.z + 0.50f * facz));



            }
        }
        else cursor.GetComponent<MeshRenderer>().enabled = false;

    }
    public void StopShip()
    {
        if (ss.GetComponent<Rigidbody>().position.x < 0)
        {
            ssx = -1;
        }
        else
        {
            ssx = 1;
        }
        ss.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ss.GetComponent<Rigidbody>().position = new Vector3((int)(ss.GetComponent<Rigidbody>().position.x + 0.5f*ssx), (int)(ss.GetComponent<Rigidbody>().position.y + 0.5f), (int)(ss.GetComponent<Rigidbody>().position.z + 0.5f));
    }
}
