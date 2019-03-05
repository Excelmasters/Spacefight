using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSolarSystem : MonoBehaviour
{
    private bool Gen = false;
    [Range(0.01f, 5)]
    public float Rotationspeed = 0.024f;
    [Range(1,15)]
    public int MaxPlanetNumber_Random = 15;
    [Range(0,10)]
    public float RandomDistanceVariation = 1.89f;
    [Range(10, 500)]
    public int Resolution = 200;
    [Range(1,200)]
    private float SolarSize = 1;
    public GameObject ParticleSunprefab;
    public GameObject PlanetTrailPrefab;


    public void Start()
    {
       Gen = true;
    }



    private void GeneratePlanet()
    {
        ParticleSunprefab = GameObject.Find("Sun");
        PlanetTrailPrefab = GameObject.Find("PlanetTrail");


        GameObject ParticleSun = GameObject.Instantiate(ParticleSunprefab) as GameObject;
        GameObject suncollider = GameObject.CreatePrimitive(PrimitiveType.Sphere) as GameObject;
        suncollider.GetComponent<MeshRenderer>().enabled = false;
        suncollider.transform.position = transform.position;
        suncollider.transform.SetParent(transform);
        float rad = 45;
        suncollider.GetComponent<SphereCollider>().transform.localScale = new Vector3(rad, rad, rad);
        suncollider.tag = ("Accident");
        suncollider.AddComponent<Rigidbody>();
        suncollider.GetComponent<Rigidbody>().useGravity = false;
        suncollider.GetComponent<Rigidbody>().isKinematic = true;





        // ParticleSun.GetComponent<SphereCollider>().transform.localScale = new Vector3(2, 2, 2);
        ParticleSun.transform.position = transform.position;
        ParticleSun.name = ("ParticleSun");
        ParticleSun.transform.SetParent(transform);

        Rotationspeed = Rotationspeed * (SolarSize * 1.5f);

        int MaxPlanetNumber_Randominsystem = (int)(Random.Range(1, MaxPlanetNumber_Random));           //Number of generated planets







        for (int i = 0; i < MaxPlanetNumber_Randominsystem; i++)
        {

            GameObject planet = new GameObject();
            planet.name = "Planet";
            planet.transform.SetParent(this.transform);
            planet.tag = ("Accident");
            planet.AddComponent<CubeSphere2>();

            GameObject PlanetTrail = GameObject.Instantiate(PlanetTrailPrefab) as GameObject;
            PlanetTrail.transform.SetParent(planet.transform);
            planet.AddComponent<RotateEarth>();
            planet.AddComponent<Rigidbody>();
            planet.GetComponent<Rigidbody>().useGravity = false;
            planet.GetComponent<Rigidbody>().isKinematic = true;
            planet.AddComponent<SphereCollider>();
            planet.GetComponent<SphereCollider>().radius = 1.05f;
            planet.GetComponent<CubeSphere2>().Planettype = (int)i / 2;

            GameObject Button = GameObject.CreatePrimitive(PrimitiveType.Sphere) as GameObject;


            Button.transform.SetParent(planet.transform);
            Button.transform.localPosition = new Vector3(0, 0, 0);
            Button.transform.position += new Vector3(0, 5, 0);
            Button.AddComponent<Buttons>();
            Button.AddComponent<Rigidbody>();
            Button.GetComponent<Rigidbody>().useGravity = false;

            Button.GetComponent<MeshRenderer>().material = GameObject.Find("Gamemanager").GetComponent<restart>().ButtonColor;
     


            planet.transform.position = transform.position;
            planet.transform.transform.Rotate(Random.Range(-45, 45), 0, Random.Range(-45, 45));
            planet.transform.position = planet.transform.position + new Vector3((Random.Range(20  - RandomDistanceVariation - 5,    20 + RandomDistanceVariation -5) * i + 40) * SolarSize, 0, 0);


            //Button.transform.localScale = new Vector3(10, 10, 10);
            Button.GetComponent<MeshRenderer>().material = GameObject.Find("Gamemanager").GetComponent<restart>().ButtonColor;
        }
    }








    void Update()
    {
        if (Gen == true)
        {
            
            GeneratePlanet();
            GameObject.Find("Sun").gameObject.SetActive(false);
            GameObject.Find("PlanetTrail").gameObject.SetActive(false);
        }
        Gen = false;
    }
}
