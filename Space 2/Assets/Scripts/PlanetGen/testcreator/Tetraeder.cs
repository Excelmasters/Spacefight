using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetraeder : MonoBehaviour
{
    Vector3[] vertices;
    int[] triangles;
    Mesh body;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Planet = new GameObject("Planet", typeof(MeshFilter), typeof(MeshRenderer));



        body = new Mesh();

        Planet.GetComponent<MeshFilter>().mesh = body;

        vertices = new Vector3[]
        {
            new Vector3(-0.5f,0,-0.5f), //adding the negative of both vectors, divide it by 2
            new Vector3(1,0,0),
            new Vector3(0,0,1),
            new Vector3(0,1,0)
        };/*
        vertices[0] = new Vector3(0, 0);
        vertices[1] = new Vector3(0, 0);
        vertices[2] = new Vector3(1, 1);
        */
        triangles = new int[]
        {
            0,1,2,
            2,1,3,
            0,3,1,
            3,0,2

            
        };
        body.vertices = vertices;
        body.triangles = triangles;



        Planet.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Standard"));
        body.RecalculateNormals();




    }


}
