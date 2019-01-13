using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGen : MonoBehaviour
{
    public GameObject prefab;
    Vector3[] newmid;
    public GameObject Planet;
    [Range(0, 10)]
    public float radius;

    public Material medal;
    private int x;
    int[] trip;
    [Range(0, 1)]
    public float ra;
    [Range(0, 1)]
    public float ra2;
    int[] oldtri;
    Mesh body;
    [Range(0, 7)]
    public int resolution;
    Noise noise = new Noise();



    static Hashtable verticeshash;


    public float Terrain(Vector3 vertice)
    {
        float terrainvalue = (noise.Evaluate(vertice)) * ra2;
        return terrainvalue;

    }



    void OnValidate()
    {
        // GameObject Planet = new GameObject("Planet", typeof(MeshFilter), typeof(MeshRenderer));

        if (Planet.GetComponent<MeshFilter>() == null) { Planet.AddComponent<MeshFilter>(); }
        if (Planet.AddComponent<MeshRenderer>() == null) { Planet.AddComponent<MeshFilter>(); }


        body = new Mesh();
        int[] trip = new int[3];
        verticeshash = new Hashtable();
        int[] oldtri = new int[1325];
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        Vector3[] verticesarray = vertices.ToArray();
        body.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        int h = new int();
        int j = new int();
        int k = new int();

        Planet.GetComponent<MeshFilter>().mesh = body;                          //creating an octaeder
        vertices.Add(new Vector3(1, 0, 1).normalized);
        vertices.Add(new Vector3(1, 0, -1).normalized);
        vertices.Add(new Vector3(-1, 0, -1).normalized);
        vertices.Add(new Vector3(-1, 0, 1).normalized);
        vertices.Add(new Vector3(0, 1, 0).normalized);
        vertices.Add(new Vector3(0, -1, 0).normalized);

        /*verticeshash.Add(0, new Vector3(1, 0, 1).normalized);
        verticeshash.Add(1, new Vector3(1, 0, -1).normalized);
        verticeshash.Add(2, new Vector3(-1, 0, -1).normalized);
        verticeshash.Add(3, new Vector3(-1, 0, 1).normalized);
        verticeshash.Add(4, new Vector3(0, 1, 0).normalized);
        verticeshash.Add(5, new Vector3(0, -1, 0).normalized);*/



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

        Debug.Log(triangles.Count / 3); ;

        for (int go = 0; go < resolution; go++)                                                         //resolution loop (essentially just repeats the process)
        {


            int trianglepointscount = triangles.Count;

            for (x = 0; x < trianglepointscount / 3; x++)                      //looping through each surface       trianglepointscount / 3
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








                    /*if (verticeshash.ContainsValue(newmid[c]))
                    {
                        verticeshash.
                    }
                    else
                    {
                        vertices.Add(newmid[c]);
                        verticeshash.Add(verticeshash.Count, newmid[c]);
                    }*/

                    if (vertices.Contains(newmid[c]))
                    {
                        trip[c] = vertices.IndexOf(newmid[c]);
                        int g = new int();

                        g = g + 1;
                        if (g > 1) { Debug.Log(g + "  points do exist"); }

                    }
                    else
                    {
                        vertices.Add(newmid[c]);
                        // trip[c] = vertices.Count - 1;
                        trip[c] = vertices.IndexOf(newmid[c]);
                    }
                    /*
                    vertices.Add(newmid[c]);
                    trip[c] = vertices.IndexOf(newmid[c]);
                    */





                }
                int a = new int();
                a = vertices.Count - 1;


                for (int e = 0; e < 3; e++)
                {
                    triangles.Add(trip[e]);

                }

                triangles.Add(oldtri[1]);
                triangles.Add(trip[1]);
                triangles.Add(trip[0]);


                /*triangles.Add(oldtri[0]);             //wrong direction
                triangles.Add(trip[2]);
                triangles.Add(trip[0]);*/

                triangles.Add(trip[0]);
                triangles.Add(trip[2]);
                triangles.Add(oldtri[0]);



                triangles.Add(oldtri[2]);
                triangles.Add(trip[2]);
                triangles.Add(trip[1]);








            }


            for (int delete = triangles.Count / 3; delete > -1; delete--)                                     //delete old tris
            {
                if (delete < 8 * Mathf.Pow(4, go) * 3)
                {
                    triangles.RemoveAt(delete);
                }

            }


            Debug.Log(triangles.Count / 3 + " Dreiecke");

            Debug.Log(vertices.Count + " vertices");


            verticesarray = vertices.ToArray();
            body.RecalculateNormals();
        }



        /*for (int i = 0; i < vertices.Count; i++)                                                                          //Test whether all vertices are added correctly (lowers performance drastically)
        {
            GameObject cube = Object.Instantiate(prefab) as GameObject;
            cube.transform.position = vertices[i];
        }*/


        
        for (int c = 0; c < vertices.Count; c++)
        {
            vertices[c] = vertices[c].normalized;
            vertices[c] = vertices[c] * (Terrain(vertices[c])+1);
        }
        for (int c = 0; c < vertices.Count; c++) { 
        vertices[c] = vertices[c] * Random.Range(1.00f + ra, 1.00f - ra); }









        Vector3[] zero = new Vector3[0];
        verticesarray = zero;
        verticesarray = vertices.ToArray();
        body.vertices = verticesarray;
        int[] trianglearray = triangles.ToArray();
        body.triangles = trianglearray;
        Planet.GetComponent<MeshRenderer>().material = medal;
        body.RecalculateNormals();
        Planet.transform.localScale = new Vector3(radius, radius, radius);


    }
}

