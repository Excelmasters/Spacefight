using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octaeder : MonoBehaviour
{
    public GameObject prefab;
    Vector3[] newmid;
    public int radius;
    private int x;
    private float hi;
    private int h;
    int[] oldtri;
    Mesh body;
    [Range(0, 20)]
    public int resolution;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Planet = new GameObject("Planet", typeof(MeshFilter), typeof(MeshRenderer));

        body = new Mesh();
        int[] oldtri = new int[1325];
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        Vector3[] verticesarray = vertices.ToArray();


        Planet.GetComponent<MeshFilter>().mesh = body;

        /* vertices = new Vector3
         {
              new Vector3(1,0,1).normalized,
              new Vector3(1,0,-1).normalized,
              new Vector3(-1,0,-1).normalized,
              new Vector3(-1,0,1).normalized,
              new Vector3(0,1,0).normalized,
              new Vector3(0,-1,0).normalized,

         };*/

        vertices.Add(new Vector3(1, 0, 1).normalized);
        vertices.Add(new Vector3(1, 0, -1).normalized);
        vertices.Add(new Vector3(-1, 0, -1).normalized);
        vertices.Add(new Vector3(-1, 0, 1).normalized);
        vertices.Add(new Vector3(0, 1, 0).normalized);
        vertices.Add(new Vector3(0, -1, 0).normalized);



        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(4);
        triangles.Add(0);
        triangles.Add(5);
        triangles.Add(1);
        triangles.Add(3);
        triangles.Add(0);
        triangles.Add(4);
        triangles.Add(3);
        triangles.Add(5);
        triangles.Add(0);
        triangles.Add(3);
        triangles.Add(4);
        triangles.Add(2);
        triangles.Add(2);
        triangles.Add(5);
        triangles.Add(3);
        triangles.Add(1);
        triangles.Add(2);
        triangles.Add(4);
        triangles.Add(1);
        triangles.Add(5);
        triangles.Add(2);


        for (int go = 0; go < resolution; go++)
        {
            

            int trianglepointscount = triangles.Count;

            for (x = 0; x < trianglepointscount / 3; x++)                      //looping through each surface  
            {

                for (int y = 0; y < 3; y++)                             //looping through each vertices of that surface 
                {
                    oldtri[y] = triangles[x * 3 + y];

                }
                Vector3[] newmid = new Vector3[3];                              //initiating the Vector3 for new Midpoints


                newmid[0] = (vertices[oldtri[0]] + vertices[oldtri[1]]) / 2;
                newmid[1] = (vertices[oldtri[1]] + vertices[oldtri[2]]) / 2;
                newmid[2] = (vertices[oldtri[2]] + vertices[oldtri[0]]) / 2;



                for (int c = 0; c < 3; c++)                                 //getting the vertices to have the same distance to the origin (which is equal to the radius)

                {
                    newmid[c] = newmid[c].normalized;                                                               //integrate the radius here
                    vertices.Add(newmid[c]);
                }
                int a = new int();
                a = vertices.Count - 1;


                for (int e = 0; e < 3; e++)                                                                                                         //`????????????
                {
                    triangles.Add(a - 2 + e);

                }

                triangles.Add(oldtri[1]);
                triangles.Add(a - 1);
                triangles.Add(a - 2);

                triangles.Add(oldtri[0]);
                triangles.Add(a - 2);
                triangles.Add(a - 0);

                triangles.Add(oldtri[2]);
                triangles.Add(a - 0);
                triangles.Add(a - 1);





                if (go != 2)
                {/*
                    for (int delete = 0; delete < 4; delete++)
                    {
                        Debug.Log(delete);
                        triangles.Remove(delete);
                    }*/
                    Debug.Log("HI");
                    triangles.Remove(0);
                    triangles.Remove(1);
                    triangles.Remove(3);
                    triangles.Remove(4);
                    triangles.Remove(5);
                    triangles.Remove(6);
                    triangles.Remove(7);
                    triangles.Remove(8);
                }
                





               





               /* for (int i = 0; i < vertices.Count; i++)                                                                          //Test whether all vertices are added correctly
                {
                    GameObject cube = Object.Instantiate(prefab) as GameObject;
                    cube.transform.position = vertices[i];
                }*/

            }
            verticesarray = vertices.ToArray();
        }



        verticesarray = vertices.ToArray(); 
        body.vertices = verticesarray;
        int[] trianglearray = triangles.ToArray();
         body.triangles = trianglearray;
        Planet.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
        body.RecalculateNormals();


    }
}

