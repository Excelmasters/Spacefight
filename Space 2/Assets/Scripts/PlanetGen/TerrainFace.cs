using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFace
{
    MeshFilter[] meshFilters;
    TerrainFace[] terrainFaces;
    Noise noise = new Noise();
    [Range(0, 10)]
    public float frequenzy;
    GameObject prefab = GameObject.FindWithTag("ball");
    [Range(0, 10)]
    public float Baseroughness;
    [Range(0, 1)]
    public float amplitude;
    public Vector3 center;
    [Range(0, 1)]
    public float persistence;
    [Range(0, 1)]
    public float minimum;
    [Range(0, 10)]
    public int numsurfaces;
    Mesh mesh;
    int resolution;
    Vector3 localUp;
    Vector3 axisA;
    Vector3 axisB;

    public TerrainFace(Mesh mesh, int resolution, Vector3 localUp)
    {
        this.mesh = mesh;
        this.resolution = resolution;
        this.localUp = localUp;

        axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        axisB = Vector3.Cross(localUp, axisA);
    }

    public void ConstructMesh()
    {
        Vector3[] vertices = new Vector3[resolution * resolution];
        int[] triangles = new int[(resolution - 1) * (resolution - 1) * 6];
        int triIndex = 0;

        for (int y = 0; y < resolution; y++)
        {
            for (int x = 0; x < resolution; x++)
            {
                int i = x + y * resolution;
                Vector2 percent = new Vector2(x, y) / (resolution - 1);
                Vector3 pointOnUnitCube = localUp + (percent.x - .5f) * 2 * axisA + (percent.y - .5f) * 2 * axisB;



                Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;
                for (int c = 0; c < vertices.Length; c++)
                {
                    pointOnUnitSphere *= (Terrain(pointOnUnitSphere) + 1);
                }




                vertices[i] = pointOnUnitSphere;

                if (x != resolution - 1 && y != resolution - 1)
                {
                    triangles[triIndex] = i;
                    triangles[triIndex + 1] = i + resolution + 1;
                    triangles[triIndex + 2] = i + resolution;

                    triangles[triIndex + 3] = i;
                    triangles[triIndex + 4] = i + 1;
                    triangles[triIndex + 5] = i + resolution + 1;
                    triIndex += 6;
                }
            }
        }
        for (int j = 0; j < vertices.Length; j++)
        {
            vertices[j] = vertices[j] * Random.Range(1.05f, 0.95f);
        }
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        for (int c = 0; c < vertices.Length; c++)                                                                          //Test whether all vertices are added correctly (lowers performance drastically)
        {
           // GameObject ball = Object.Instantiate(prefab) as GameObject;
            //ball.transform.position = vertices[c];
            // cube.transform.parent = Planet.transform;
        }
        mesh.RecalculateNormals();
    }



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
        terrainvalue = Mathf.Max(0, terrainvalue - minimum);
        return terrainvalue;
    }

}