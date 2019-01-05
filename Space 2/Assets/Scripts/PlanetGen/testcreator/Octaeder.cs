using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octaeder : MonoBehaviour
{
    public GameObject prefab;
    Vector3[] newmid;
    public GameObject Planet;
    public int radius;
    private int x;
    private float hi;
    [Range(0, 1000)]
    public float ra;
    private int h;
    int[] oldtri;
    Mesh body;
    [Range(0, 8)]
    public int resolution;





    void OnValidate()
    {
        // GameObject Planet = new GameObject("Planet", typeof(MeshFilter), typeof(MeshRenderer));

        if (Planet.GetComponent<MeshFilter>() == null) { Planet.AddComponent<MeshFilter>(); }
        if (Planet.AddComponent<MeshRenderer>() == null) { Planet.AddComponent<MeshFilter>(); }


        body = new Mesh();
        int[] oldtri = new int[1325];
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        Vector3[] verticesarray = vertices.ToArray();
        body.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;


        Planet.GetComponent<MeshFilter>().mesh = body;                          //creating an octaeder
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

        Debug.Log(triangles.Count / 3);;

        for (int go = 0; go < resolution; go++)                                                         //resolution loop (essentially just repeats the process)
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



                for (int c = 0; c < 3; c++)                                

                {
                    newmid[c] = newmid[c].normalized;
                    //newmid[c] = newmid[c].normalized * Mathf.PerlinNoise(1.00f+ra,1.00f-ra);                                                              //getting the vertices to have the same distance to the origin (which is equal to the radius) 
                    vertices.Add(newmid[c]);
                }
                int a = new int();
                a = vertices.Count - 1;


                for (int e = 0; e < 3; e++)                                                                                                        
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

   



            

               /* for (int i = 0; i < vertices.Count; i++)                                                                          //Test whether all vertices are added correctly (lowers performance drastically)
                {
                    GameObject cube = Object.Instantiate(prefab) as GameObject;
                    cube.transform.position = vertices[i];
                }*/

            }


             for (int delete = triangles.Count/3; delete>-1; delete--)
             {
                if (delete < 8 * Mathf.Pow(4, go)*3)
                {
                    triangles.RemoveAt(delete);
                }

             }


            Debug.Log(triangles.Count/3);



            verticesarray = vertices.ToArray();
            body.RecalculateNormals();
        }

        Vector3[] zero = new Vector3[0];
        verticesarray = zero;
        verticesarray = vertices.ToArray(); 
        body.vertices = verticesarray;
        int[] trianglearray = triangles.ToArray();
         body.triangles = trianglearray;
        Planet.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
        body.RecalculateNormals();
        Planet.transform.localScale = new Vector3(radius, radius, radius);


    }
}

