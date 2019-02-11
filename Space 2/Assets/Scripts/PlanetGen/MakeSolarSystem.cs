using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSolarSystem : MonoBehaviour
{
    public bool Gen;
    public int planetCounter;
    public Gradient[] gradient = new Gradient[2];
    public GameObject PlanetTrail;
    [Range(0.1f, 10)]
    public float Rotationspeed;
    [Range(1,15)]
    public int MaxPlanetNumber_Random;
    [Range(0,10)]
    public float RandomDistanceVariation;
    [Range(10, 500)]
    public int Resolution;
    


    private void GeneratePlanet()
    {




        //int MaxPlanetNumber_Randominsystem = (int)(Random.Range(1, MaxPlanetNumber_Random));           //Number of generated planets

        for (int i = 0; i < 10; i++)
        {

            GameObject planet = new GameObject();
            planet.name = "Planet" + (i+1);
            planet.transform.SetParent(this.transform);
            planet.AddComponent<CubeSphere2>();
            planet.AddComponent<RotateEarth>();
            planet.AddComponent<Rigidbody>();
            planet.GetComponent<Rigidbody>().useGravity = false;
            planet.GetComponent<Rigidbody>().isKinematic = true;
            planet.AddComponent<SphereCollider>();
            planet.GetComponent<SphereCollider>().radius = 1.05f;
            planet.GetComponent<CubeSphere2>().Planettype = (int)i / 2;



            //GameObject PlanetTrailinstance = GameObject.Instantiate(PlanetTrail) as GameObject;
            // PlanetTrailinstance.transform.SetParent(planet.transform);
            // PlanetTrailinstance.transform.position = Vector3.zero;

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




            planet.transform.transform.Rotate(Random.Range(-45, 45), 0, Random.Range(-45, 45));
            planet.transform.position = planet.transform.position + new Vector3(Random.Range(35  - RandomDistanceVariation - 5,45 + RandomDistanceVariation -5) * i + 150, 0, 0);
        }
    }








    void Update()
    {
        if (Gen == true)
        {
           // PlanetTrail = GameObject.Find("PlanetTrail");
            GeneratePlanet();

            Gen = false;
        }
    }
}
