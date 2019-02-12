using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSolarSystem : MonoBehaviour
{
    private bool Gen = false;
    [Range(0.01f, 1)]
    public float Rotationspeed = 0.024f;
    [Range(1,15)]
    public int MaxPlanetNumber_Random = 15;
    [Range(0,10)]
    public float RandomDistanceVariation = 1.89f;
    [Range(10, 500)]
    public int Resolution = 200;
    [Range(1,20)]
    public float SolarSize;


    public void Start()
    {
       Gen = true;
    }



    private void GeneratePlanet()
    {   
        Rotationspeed = Rotationspeed * (SolarSize * 1.5f);

        int MaxPlanetNumber_Randominsystem = (int)(Random.Range(1, MaxPlanetNumber_Random));           //Number of generated planets
        GameObject Sun = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Sun.name = "Sun";
        Sun.tag = ("Accident");
        Sun.AddComponent<Rigidbody>();
        Sun.GetComponent<Rigidbody>().useGravity = false;
        Sun.GetComponent<Rigidbody>().isKinematic = true;
        Sun.transform.SetParent(transform);
        Sun.transform.position = transform.position;
        Sun.transform.localScale = new Vector3(50 * SolarSize, 50 * SolarSize, 50 * SolarSize);


        if (MaxPlanetNumber_Randominsystem > 5)
        {
            Sun.GetComponent<MeshRenderer>().material.color = Color.blue;

        }
        else
        {
            Sun.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }




        for (int i = 0; i < MaxPlanetNumber_Randominsystem; i++)
        {

            GameObject planet = new GameObject();
            planet.name = "Planet" + (i+1);
            planet.transform.SetParent(this.transform);
            planet.tag = ("Accident");
            planet.AddComponent<CubeSphere2>();
            planet.AddComponent<RotateEarth>();
            planet.AddComponent<Rigidbody>();
            planet.GetComponent<Rigidbody>().useGravity = false;
            planet.GetComponent<Rigidbody>().isKinematic = true;
            planet.AddComponent<SphereCollider>();
            planet.GetComponent<SphereCollider>().radius = 1.05f;
            planet.GetComponent<CubeSphere2>().Planettype = (int)i / 2;

            planet.AddComponent<TrailRenderer>();
            TrailRenderer tr = planet.GetComponent<TrailRenderer>();
            tr.material = new Material(Shader.Find("Sprites/Default"));
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.blue, 0.9f), new GradientColorKey(Color.grey, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(0.5f, 0.0f), new GradientAlphaKey(0f, 1.0f) }
            );
            tr.colorGradient = gradient;
            tr.time = 100;


            AnimationCurve curve = new AnimationCurve();


            curve.AddKey(0.0f, 1.0f);
            curve.AddKey(1.0f, 0.0f);

            tr.widthCurve = curve;
            tr.widthMultiplier = 1;



            planet.transform.position = transform.position;
            planet.transform.transform.Rotate(Random.Range(-45, 45), 0, Random.Range(-45, 45));
            planet.transform.position = planet.transform.position + new Vector3((Random.Range(20  - RandomDistanceVariation - 5,    20 + RandomDistanceVariation -5) * i + 40) * SolarSize, 0, 0);
        }
    }








    void Update()
    {
        if (Gen == true)
        {
            
            GeneratePlanet();
        }
        Gen = false;
    }
}
