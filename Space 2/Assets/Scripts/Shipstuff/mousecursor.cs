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
    public GameObject ss;
    private Vector3 posi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {       

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "buildingcube")
            {
                cursor.GetComponent<MeshRenderer>().enabled = true;
                if (Input.GetMouseButtonDown(1))
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
        ss.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
