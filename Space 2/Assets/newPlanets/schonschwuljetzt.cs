using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schonschwuljetzt : MonoBehaviour
{
    [Range(5,1000)]
    public int resolution;
    public int size = 1;
    private int count;
    public Material mat;
    Noise noise = new Noise();
    [Range(0,5)]
    public float frequenzy = 1;
    [Range(0,1)]
    public float height = 1;

    // Update is called once per frame
    void OnValidate()
    {


        List<int> triangleslist = new List<int>();
        Mesh mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        this.gameObject.AddComponent<MeshFilter>();
        int[] triangles = new int[(resolution-1) * (resolution -1) * 2 * 3];

        gameObject.AddComponent<MeshRenderer>();
        gameObject.GetComponent<MeshRenderer>().material = mat;
        Vector3[] vertices = new Vector3[resolution * resolution];
        int num = 0;
        for(int x = 0; x< resolution; x++)
        {
            for(int y = 0; y < resolution; y++)
            {
               

                vertices[num] = new Vector3((float)x/(resolution-1), 0, (float)y / (resolution-1)) * size;
                vertices[num].y +=  ((noise.Evaluate(vertices[num] * frequenzy)+1) * height);

                num++;




            }
        }
        for (int j = 0; j < resolution - 1; j++)
        {
            for (int i = 0; i < resolution - 1; i++)
            {
                triangleslist.Add(i + 1 + resolution * j);
                triangleslist.Add(resolution + 1 + i + resolution * j);
                triangleslist.Add(i + resolution * j);
                triangleslist.Add(resolution + 1 + i + resolution * j);
                triangleslist.Add(resolution + i + resolution * j);
                triangleslist.Add(i + resolution * j);

            }
        }

        triangles = triangleslist.ToArray();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        GetComponent<MeshFilter>().mesh = mesh;
        for (int i = 0; i < vertices.Length; i++)
        {
            //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere) as GameObject;
           // sphere.transform.position = GetComponent<MeshFilter>().mesh.vertices[i];
            //sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }
}
