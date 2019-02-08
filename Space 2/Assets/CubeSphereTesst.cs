using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeSphereTesst : MonoBehaviour
{
    
    private GameObject Gen;
    private GameObject meshObj;
    [Range(1, 500)]
    public int resolution = 100;
    public Vector3 center;
    Noise noise = new Noise();
    public int size;
    public Vector3[] normal;
    public bool doesexist = false;
    public Gradient[] gradient = new Gradient[2];
    [Range(0, 5)]
    public float startingfrequenzy = 0.6f;
    [Range(1, 10)]
    public int numsurfaces = 9;
    [Range(1, 5)]
    public float frequenzychange = 4f;
    [Range(0, 1)]
    public float heightchange = 0.25f;
    public float radius = 1;
    [Range(0, 3)]
    public float minimum = 0.4f;








    public Material spherematerial;







    private float v;
    Texture2D texture;
    const int textureResolution = 50;

    public float Min { get; private set; }
    public float Max { get; private set; }













    /*public float Terrain(Vector3 vertice)
    {
        float terrainvalue = 0;
        for (int i = 0; i < numsurfaces; i++)
        {
            float k = (noise.Evaluate(vertice * frequenzy + center));
            terrainvalue += (k + 1) * 0.5f * amplitude;

            frequenzy *= Baseroughness;
            amplitude *= persistence;

        }
        terrainvalue = Mathf.Max(0, terrainvalue - mininum);
       Debug.Log(terrainvalue * strength);
        return terrainvalue * strength;
    }*/










    public Vector3 Terrain(Vector3 vertice)
    {
        float terrainvalue = 0;
        float roughness = startingfrequenzy;
        float amplitude = 1;
        for (int i = 0; i < numsurfaces; i++)
        {
            float terrainfactor = noise.Evaluate(vertice * roughness + center);
            terrainvalue += (terrainfactor + 1) * 0.25f * amplitude;
            roughness = roughness * frequenzychange;
            amplitude = amplitude * heightchange;
        }
        terrainvalue = Mathf.Max(0, terrainvalue - minimum);
        v = (terrainvalue + 1);

        if (v > Max)
        {
            Max = v;
        }
        if (v < Min)
        {
            Min = v;
        }


        return v * vertice;
    }











    public void OnValidate()
    {
        //spherematerial = transform.parent.GetComponent<MeshRenderer>().material;
        GradientColorKey[] colorKey;
        GradientAlphaKey[] alphaKey;
        for (int i = 0; i < gradient.Length; i++)
        {
            gradient[i] = new Gradient();
        }


        colorKey = new GradientColorKey[7];
        colorKey[0].time = 0f;
        colorKey[1].time = 0.01f;
        colorKey[2].time = 0.179f;
        colorKey[3].time = 0.382f;
        colorKey[4].time = 0.4f;
        colorKey[5].time = 0.75f;
        colorKey[6].time = 1f;
        float b = 50;
        colorKey[0].color = new Color(32f, 13f, 243f) / b;
        colorKey[1].color = new Color(236f, 182f, 19f) / b;
        colorKey[2].color = new Color(24f, 135f, 24f) / b;
        colorKey[3].color = new Color(221f, 142f, 43f) / b;
        colorKey[4].color = new Color(221f, 145f, 42f) / b;
        colorKey[5].color = new Color(217f, 203f, 21f) / b;
        colorKey[6].color = new Color(255f, 255f, 255f) / b;
        alphaKey = new GradientAlphaKey[0];
        gradient[0].SetKeys(colorKey, alphaKey);


        colorKey[0].time = 0f;
        colorKey[1].time = 0.01f;
        colorKey[2].time = 0.179f;
        colorKey[3].time = 0.382f;
        colorKey[4].time = 0.4f;
        colorKey[5].time = 0.75f;
        colorKey[6].time = 1f;
        b = 250;
        colorKey[0].color = new Color(32f, 13f, 243f) / b;
        colorKey[1].color = new Color(236f, 182f, 19f) / b;
        colorKey[2].color = new Color(24f, 135f, 24f) / b;
        colorKey[3].color = new Color(221f, 142f, 43f) / b;
        colorKey[4].color = new Color(221f, 145f, 42f) / b;
        colorKey[5].color = new Color(217f, 203f, 21f) / b;
        colorKey[6].color = new Color(255f, 255f, 255f) / b;
        gradient[1].SetKeys(colorKey, alphaKey);




        int Gradientnumber = new int();
        Gradientnumber = 0;
        float random = Random.Range(0f, 1f);
        Debug.Log("Random number is " + random);
        if (random > 0.5f)
        {
            Gradientnumber = 1;
            Debug.Log(Gradientnumber);
        }
        else
        {
            Gradientnumber = 0;
            Debug.Log(Gradientnumber);
        }








        texture = new Texture2D(textureResolution, 1);

        Color[] colours = new Color[textureResolution];

        for (int i = 0; i < textureResolution; i++)
        {
            colours[i] = gradient[1].Evaluate(i / (textureResolution - 1f));
        }
        texture.SetPixels(colours);
        texture.Apply();
        spherematerial.SetTexture("_TextureOfPlanet", texture);








        v = 0;
        Min = 1;
        Max = 1;
        center = new Vector3(Random.Range(10f, -10f), Random.Range(10f, -10f), Random.Range(10f, -10f));
        Gen = this.gameObject;
        normal = new Vector3[6];
        normal[0] = Vector3.up;
        normal[1] = Vector3.down;
        normal[2] = Vector3.left;
        normal[3] = Vector3.right;
        normal[4] = Vector3.forward;
        normal[5] = Vector3.back;

        Mesh mesh = new Mesh();


        if (Gen.GetComponent<MeshFilter>() == null) { Gen.AddComponent<MeshFilter>(); }
        if (Gen.AddComponent<MeshRenderer>() == null) { Gen.AddComponent<MeshFilter>(); }


        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        vertices.Clear();

        for (int k = 0; k < 6; k++)
        {


            Vector3 AxisA = new Vector3(normal[k].y, normal[k].z, normal[k].x);
            Vector3 AxisB = Vector3.Cross(normal[k], AxisA);

            /* GameObject ball2 = Object.Instantiate(prefab2) as GameObject;
             ball2.transform.position = AxisA ;

             GameObject ball3 = Object.Instantiate(prefab2) as GameObject;
             ball3.transform.position = AxisB;*/

            for (int y = 0; y < resolution; y++)
            {
                for (int x = 0; x < resolution; x++)
                {
                    Vector2 percent = new Vector2(x, y) / (resolution - 1);
                    Vector3 pointOnUnitCube = normal[k] + (percent.x - .5f) * 2 * AxisA + (percent.y - .5f) * 2 * AxisB;
                   // Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;
                    vertices.Add(Terrain(pointOnUnitCube));







                }

            }




            for (int h = 0; h < resolution - 1; h++)
            {

                for (int i = 0; i < resolution - 1; i++)
                {
                    triangles.Add(0 + i + h * resolution + k * resolution * resolution);
                    triangles.Add(1 + i + h * resolution + k * resolution * resolution);
                    triangles.Add(resolution + i + 1 + h * resolution + k * resolution * resolution);

                    triangles.Add(resolution + i + 1 + h * resolution + k * resolution * resolution);
                    triangles.Add(resolution + i + h * resolution + k * resolution * resolution);
                    triangles.Add(0 + i + h * resolution + k * resolution * resolution);



                }
            }


        }

















        mesh.Clear();




        Gen.GetComponent<MeshRenderer>().sharedMaterial = spherematerial;
        Gen.GetComponent<MeshRenderer>().sharedMaterial.SetVector("_HeightofVertice", new Vector4(Min, Max));

        Vector3[] verticesarray = new Vector3[vertices.Count];
        verticesarray = vertices.ToArray();
        mesh.vertices = verticesarray;
        int[] trianglearray = triangles.ToArray();
        mesh.triangles = trianglearray;
        Debug.Log("Das Minimum ist " + Min);
        Debug.Log("Das Maximum ist " + Max);
        mesh.RecalculateNormals();
        Gen.GetComponent<MeshFilter>().mesh = mesh;
        transform.localScale = new Vector3(radius, radius, radius);



    }




}

