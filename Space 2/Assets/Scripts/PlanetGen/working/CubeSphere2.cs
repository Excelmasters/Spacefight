using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeSphere2 : MonoBehaviour
{
    public GameObject prefab;
    public GameObject prefab2;
    public GameObject Gen;
    private GameObject meshObj;
    public float radius;
    [Range(0, 10)]
    public int resolution = 4;
    private Vector3 center;
    Noise noise = new Noise();
    public Material medal;
    public int size;
    public Vector3[] normal;
    public bool doesexist = false;


    [Range(0, 1)]
    public float ra;
    [Range(0, 1)]
    public float mininum;
    
    public float amplitude;
    public float frequenzy;
    [Range(0, 10)]
    public int numsurfaces = 1;
    public float minimum;
    [Range(0, 1)]
    public float persistence = 0.6f;
    [Range(0, 10)]
    public float roughness;
    [Range(0, 10)]
    public float strength;

    [Range(0, 10)]
    public float Baseroughness = 2;

    public GameObject Prefab { get => prefab; set => prefab = value; }













    public Vector3 Terrain(Vector3 vertice)
    {
        // center.x = Random.Range(-1f, 1f);
        //center.z = Random.Range(-1f, 1f);
        //center.y = Random.Range(-1f, 1f);


        float TerrainValue = (noise.Evaluate((vertice * Baseroughness)) * amplitude);
        float elevation = TerrainValue;
        return vertice * (TerrainValue + 1);
    }














    public void OnValidate()
    {
        normal = new Vector3[6];
        normal[0] = Vector3.up;
        normal[1] = new Vector3(-1,0,0);
        normal[2] = new Vector3(0, 1, 0);
        normal[3] = new Vector3(0, -1, 0);
        normal[4] = new Vector3(0, 0, 1);
        normal[5] = new Vector3(0, 0, -1);

        Mesh mesh = new Mesh();


            if (Gen.GetComponent<MeshFilter>() == null) { Gen.AddComponent<MeshFilter>(); }
            if (Gen.AddComponent<MeshRenderer>() == null) { Gen.AddComponent<MeshFilter>(); }


            List<Vector3> vertices = new List<Vector3>();
            List<int> triangles = new List<int>();
            mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
            vertices.Clear();








        GameObject ball5 = Object.Instantiate(prefab) as GameObject;
        ball5.transform.position = Vector3.zero;

        for (int k = 0; k < 2; k++)
        {


            Vector3 AxisA = new Vector3(normal[k].y, normal[k].z, normal[k].x);
            Vector3 AxisB = Vector3.Cross(normal[k] , AxisA);

           /* GameObject ball2 = Object.Instantiate(prefab2) as GameObject;
            ball2.transform.position = AxisA ;

            GameObject ball3 = Object.Instantiate(prefab2) as GameObject;
            ball3.transform.position = AxisB;*/


            for (int y = 0; x < resolution; x++)
            {
                for (int x = 0; y < resolution; y++)
                {
                    Vector2 percent = new Vector2(x, y) / (resolution - 1);
                    Vector3 pointOnUnitCube = normal[k] + (percent.x - .5f) * 2 * axisA + (percent.y - .5f) * 2 * axisB;
                    Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;
                    vertices.Add(pointOnUnitSphere);
                }

            }
            for(int x = 0; x < vertices.Count; x++)
            {
                GameObject ball4 = Object.Instantiate(prefab2) as GameObject;
                ball4.transform.position = vertices[x];
            }
        }


        


                for (int i   = 0; i < 2; i++)
        {
            GameObject ball = Object.Instantiate(prefab) as GameObject;
            ball.transform.position = normal[i];
        }

            


























            /* for (int h = 0; h < resolution; h++)
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

             }*/









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
            mesh.RecalculateNormals();

            Gen.GetComponent<MeshFilter>().mesh = mesh;
            
        









      

    }























}

