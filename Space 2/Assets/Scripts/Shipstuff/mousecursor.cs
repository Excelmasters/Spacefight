using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousecursor : MonoBehaviour
{
    RaycastHit hit;
    public Camera cam;
    public GameObject cursor;
    private int flipx;
    private int flipy;
    private int flipz;
    private int factor;
    private Vector3 posi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        /*Debug.Log(cam.transform.eulerAngles.x);
         if ((cam.transform.eulerAngles.y < 90 & cam.transform.eulerAngles.y > 0) | (cam.transform.eulerAngles.y < 360  & cam.transform.eulerAngles.y > 270)  )
        {
            flipz = -1;
        }
        else
        {
            flipz = 1;
        }
        if (cam.transform.rotation.x > 0)
        {
            flipy = -1;
            Debug.Log("flip it");
        }
        else
        {
            flipy = 1;
            Debug.Log("dont flip it");
        }
        if ((cam.transform.eulerAngles.z < 90 & cam.transform.eulerAngles.z > 0) | (cam.transform.eulerAngles.z < 360 & cam.transform.eulerAngles.z > 270))
        {
            flipx = -1;

        }
        else
        {
            flipx = 1;

        }*/

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            cursor.GetComponent<MeshRenderer>().enabled = true;
            if (hit.collider.gameObject.tag == "buildingcube")
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Debug.Log("rechte maustaste");
                    Destroy(hit.collider.gameObject);
                }





                 Debug.Log("Ich hab was getroffen");
                 Debug.Log(hit.point.x + "  " + ((int)posi.x+0.5f) + "  "+  hit.point.y + "  " + ((int)posi.y + 0.5f) + "  " + hit.point.z + "  " + ((int)posi.z + 0.5f));

                //Vector3 posi = new Vector3((int)(hit.point.x + 0.5f*flipx), (int)(hit.point.y + 0.5f*flipy), (int)(hit.point.z + 0.5f*flipz));
                if (hit.normal.x < 0 | hit.normal.y < 0 | hit.normal.z < 0)
                {
                    factor = 1;
                }
                else
                {
                    factor = 0;
                }
                posi = hit.point + (hit.normal * factor);
                Debug.Log(hit.normal);


                cursor.transform.position = new Vector3((int)(posi.x+0.5f),(int)(posi.y+0.5f),(int)(posi.z + 0.5f));


            }
        }
        else cursor.GetComponent<MeshRenderer>().enabled = false;

    }
}
