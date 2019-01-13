using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<int> triangles = new List<int>();
        for (int x = 0; x < 5; x++)
        {
          if (triangles.Contains(1) != true)
            {
                triangles.Add(1);
            }
        }
        Debug.Log(triangles.Count + "  Elements in list");
    }


}
