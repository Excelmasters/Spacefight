using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select : MonoBehaviour
{
    public Vector3 roundedMousePosition;
    public GameObject cursor;


    // Update is called once per frame
    void Update()
    {
        SelectLocation();
    }
    private void SelectLocation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            
            int x = Mathf.FloorToInt(hitInfo.point.x);
            int z = Mathf.FloorToInt(hitInfo.point.z);
            int y = Mathf.FloorToInt(hitInfo.point.y);
            cursor.GetComponent<Rigidbody>().position = new Vector3(x, y, z);


            Debug.Log(roundedMousePosition);
        }
    }
}


