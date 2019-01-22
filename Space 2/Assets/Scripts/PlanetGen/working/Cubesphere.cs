using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cubesphere : MonoBehaviour
{
    public GameObject prefab;
    public GameObject Gen;
    private GameObject meshObj;
    public float radius;
    [Range(0, 500)]
    public int resolution;
    public Vector3 center;
    Noise noise = new Noise();
    public Material medal;
    public int size;
    public bool doesexist = false;




    [Range(0, 1)]
    public float ra;
    [Range(0, 1)]
    public float mininum;
    [Range(0, 1)]
    public float amplitude;
    [Range(0, 10)]
    public float frequenzy = 1;
    [Range(0, 10)]
    public int numsurfaces = 1;

    [Range(0, 1)]
    public float persistence = 0.6f;

    [Range(0, 10)]
    public float Baseroughness = 2;

    public GameObject Prefab { get => prefab; set => prefab = value; }










    public float Terrain(Vector3 vertice)
    {

        float terrainvalue = 0;
        float basefre = frequenzy;
        float depth = amplitude;
        for (int i = 0; i < numsurfaces; i++)
        {
            float k = (noise.Evaluate(vertice * basefre + center));
            terrainvalue += (k + 1) * 0.5f * depth;

            basefre *= Baseroughness;
            depth *= persistence;

        }
        terrainvalue = Mathf.Max(0, terrainvalue - mininum);
        return terrainvalue;
    }














    private void OnValidate()
    {

        Mesh mesh = new Mesh();
        for (int f = 0; f < 6; f++)
        {
            
            if (Gen.GetComponent<MeshFilter>() == null) { Gen.AddComponent<MeshFilter>(); }
            if (Gen.AddComponent<MeshRenderer>() == null) { Gen.AddComponent<MeshFilter>(); }


            List<Vector3> vertices = new List<Vector3>();
            List<int> triangles = new List<int>();
            mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
            vertices.Clear();
            //vertices.Add(new Vector3(0, 0, 0));
            //vertices.Add(new Vector3(1, 0, 0));
            // vertices.Add(new Vector3(1, 1, 0));
            //vertices.Add(new Vector3(0, 1, 0));


            for (int i = 0; i < resolution + 1; i++)
            {
                for (int h = 0; h < resolution + 1; h++)
                {
                    vertices.Add(new Vector3((float)h / resolution * size - 0.5f, (float)i / resolution * size - 0.5f, 0 - 0.5f));
                }




            }
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i] = vertices[i].normalized;
            }
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i] = vertices[i] * (Terrain(vertices[i]) + 1);
            }










            for (int h = 0; h < resolution; h++)
            {
                for (int i = 0; i < resolution; i++)
                {
                    triangles.Add((i) + h * (resolution + 1));
                    triangles.Add((i + resolution + 1 + 1) + h * (resolution + 1));
                    triangles.Add((i + 1) + h * (resolution + 1));
                    triangles.Add((i) + h * (resolution + 1));
                    triangles.Add((i + resolution + 1) + h * (resolution + 1));
                    triangles.Add((i + resolution + 1 + 1) + h * (resolution + 1));
                }

            }









            /*for (int c = 0; c < vertices.Count; c++)                                                                          //Test whether all vertices are added correctly (lowers performance drastically)
            {
                GameObject ball = Object.Instantiate(prefab) as GameObject;
                ball.transform.position = vertices[c];
               // cube.transform.parent = Planet.transform;
            }*/
            //Debug.Log(vertices.Count / 3);








            mesh.Clear();
            Vector3[] verticesarray = new Vector3[vertices.Count];
            verticesarray = vertices.ToArray();
            mesh.vertices = verticesarray;
            int[] trianglearray = triangles.ToArray();
            mesh.triangles = trianglearray;
            Gen.GetComponent<MeshRenderer>().material = medal;
            Gen.transform.position = new Vector3(-0.5f, -0.5f, -0.5f);
            mesh.RecalculateNormals();
        }
            

        for (int i = 0; i < 6; i++)
        {
            if (Gen.transform.childCount < 6)
            {
                meshObj = new GameObject();
                meshObj = new GameObject("mesh" + i);
                meshObj.transform.parent = Gen.transform;
                meshObj.AddComponent<MeshRenderer>().sharedMaterial = medal;
                meshObj.AddComponent<MeshFilter>();
            }
        }
        for (int i = 0; i < 6; i++)
        {
            Gen.transform.GetChild(i).GetComponent<MeshFilter>().mesh = mesh;
        }







            if (doesexist == false)
        {
            Gen.transform.GetChild(0).position = new Vector3(0, 0, 0);
            Gen.transform.GetChild(0).Rotate(0, -180, 0);

            Gen.transform.GetChild(1).position = new Vector3(0, 0, 0);
            Gen.transform.GetChild(1).Rotate(0, -90, 0);

            Gen.transform.GetChild(2).position = new Vector3(0, 0, 0);
            Gen.transform.GetChild(2).Rotate(0, 90, 0);

            Gen.transform.GetChild(3).position = new Vector3(0, 0, 0);
            Gen.transform.GetChild(3).Rotate(-90, 90, 0);

            Gen.transform.GetChild(4).position = new Vector3(0, 0, 0);
            Gen.transform.GetChild(4).Rotate(90, 90, 0);
            doesexist = true;
        }



















    }




}