using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetraeder : MonoBehaviour
{
    Vector3[] vertices;
    int[] triangles; 
    public int radius;
    private int x;
    private int h;
    Mesh body;
    [Range(1,20)]
    public int resolution;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Planet = new GameObject("Planet", typeof(MeshFilter), typeof(MeshRenderer));
        Vector3[] vertices = new Vector3[4*resolution];
        int[] oldtri = new int[3];

        body = new Mesh();

        Planet.GetComponent<MeshFilter>().mesh = body;

        vertices = new Vector3[]
        {
            new Vector3(-0.5f,0,-0.5f), //adding the negative of both vectors, divide it by 2
            new Vector3(1,0,0),
            new Vector3(0,0,1),
            new Vector3(0,1,0)
        };

        triangles = new int[]
        {
            0,1,2,
            2,1,3,
            0,3,1,
            3,0,2

            
        };
       for (x = 0; x <  triangles.Length/3; x ++)
        {

            for (int y = 0; y < 3; y++)
            {
                oldtri[y] = (triangles[x * 3 + y]);
            }

            
        }
        h = 0;
        while (h < oldtri.Length)
        {
            Debug.Log(oldtri[h]);
        }




        body.vertices = vertices;
        body.triangles = triangles;



        Planet.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
        body.RecalculateNormals();




    }


}
