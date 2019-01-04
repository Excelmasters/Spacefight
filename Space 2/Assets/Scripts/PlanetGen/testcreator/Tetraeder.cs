using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetraeder : MonoBehaviour
{
    Vector3[] vertices;
    int[] triangles;
    Vector3[] newmid;
    public int radius;
    private int x;
    private float hi;
    private int h;
    Mesh body;
    [Range(1, 20)]
    public int resolution;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Planet = new GameObject("Planet", typeof(MeshFilter), typeof(MeshRenderer));
        Vector3[] vertices = new Vector3[4 * resolution];
        int[] oldtri = new int[3];

        body = new Mesh();

        Planet.GetComponent<MeshFilter>().mesh = body;

        vertices = new Vector3[]
        {
            new Vector3(-0.5f,0,-Mathf.Sqrt(0.75f)).normalized, //adding the negative of both vectors, divide it by 2
            new Vector3(1,0,0).normalized,                     //integrate the radius here
            new Vector3(-0.5f,0,Mathf.Sqrt(0.75f)).normalized,
            new Vector3(0,1,0).normalized
        };

        triangles = new int[]
        {
            0,1,2,
            2,1,3,
            0,3,1,
            3,0,2


        };
        for (x = 0; x < triangles.Length / 3; x++)                      //looping through each surface  
        {

            for (int y = 0; y < 3; y++)                             //looping through each vertices of that surface 
            {
                oldtri[y] = triangles[x * 3 + y];

            }
            Vector3[] newmid = new Vector3[3];                              //initiating the Vector3 for new Midpoints

            for (int y = 0; y < 2; y++)                                                     //Calculating the midpoint
            {
                newmid[y] = (vertices[oldtri[y]] + vertices[oldtri[y + 1]]) / 2;
                if (y == 2)
                {
                    newmid[y] = (vertices[oldtri[2]] + vertices[oldtri[0]])/2;
                }
            }
            for (int c = 0; c < 3; c++)                                 //printing the midpoint
            {
                Debug.Log(newmid[c].x);
                Debug.Log(newmid[c].y);
                Debug.Log(newmid[c].z);
            }
            for (int c = 0; c < 3; c++)                                 //getting the vertices to have the same distance to the origin (which is equal to the radius)
            {
                newmid[c] = newmid[c].normalized;                           //integrate the radius here
            }


            if (x == 0)                                 //temporarily to Debug
            {
                x = 10; 
            }



















            body.vertices = vertices;
            body.triangles = triangles;



            Planet.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
            body.RecalculateNormals();




        }


    }
}
