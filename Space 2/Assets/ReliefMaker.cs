using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliefMaker : MonoBehaviour
{

    [Range(0, 1)]
    public float mininum;
    [Range(0, 1)]
    public float amplitude;
    [Range(0, 10)]
    public float frequenzy = 1;
    [Range(0, 10)]
    public int numsurfaces = 1;
    Noise noise = new Noise();
    [Range(0, 1)]
    public float persistence = 0.6f;
    public Vector3 center;
    public GameObject planet;
    [Range(0, 10)]
    public float Baseroughness = 2;





    public float TerrainGen(Vector3 vertice)
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


    public void Update()
    {
        for (int f = 0; f < planet.transform.GetComponent<MeshFilter>().mesh.vertices.Length; f++)
        {
            transform.GetComponent<MeshFilter>().mesh.vertices[f] = transform.GetComponent<MeshFilter>().mesh.vertices[f] * (TerrainGen(transform.GetComponent<MeshFilter>().mesh.vertices[f])    +1      );

        }

    }
    /*public void Update()
    {
        Debug.Log(transform.GetComponent<MeshFilter>().mesh.vertices.Length);
    }*/
}
