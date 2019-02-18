using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetraeder : MonoBehaviour
{
    Vector3[] vertices;
    List<int> triangles;
    public GameObject prefab;
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

       /* vertices = new Vector3[]
        {
            new Vector3(-0.5f,0,-Mathf.Sqrt(0.75f)).normalized, //adding the negative of both vectors, divide it by 2
            new Vector3(1,0,0).normalized,                     //integrate the radius here
            new Vector3(-0.5f,0,Mathf.Sqrt(0.75f)).normalized,
            new Vector3(0,1,0).normalized
        };*/

            vertices[0] = new Vector3(-0.5f, 0, -Mathf.Sqrt(0.75f)).normalized;
        vertices[1] = new Vector3(1, 0, 0).normalized;
        vertices[2] = new Vector3(-0.5f, 0, Mathf.Sqrt(0.75f)).normalized;
        vertices[3] = new Vector3(0, 1, 0).normalized;

















        /* triangles = new int[]
          {
              0,1,2,
              2,1,3,
              0,3,1,
              3,0,2


          };*/
        triangles.Add(0);
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 3;
        triangles[6] = 0;
        triangles[7] = 3;
        triangles[8] = 1;
        triangles[9] = 3;
        triangles[10] = 0;
        triangles[11] = 2;













        for (x = 0; x < 4; x++)                      //looping through each surface  
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
               // newmid[c] = newmid[c].normalized;                                                               //integrate the radius here
                GameObject cube = Object.Instantiate(prefab) as GameObject;
                cube.transform.position = newmid[c];
                vertices[4+c+x*3+1] = new Vector3(newmid[c].x, newmid[c].y, newmid[c].z);
                Debug.Log(4 + c + x * 3 + 1 );
            }





            if (x == 4)                                 //temporarily to Debug
            {
                x = 10; 
            }



















            body.vertices = vertices;
            int[] tris = triangles.ToArray();
            body.triangles = tris;




            Planet.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
            body.RecalculateNormals();




        }


    }
}
