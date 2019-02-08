﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlanet : MonoBehaviour
{
    public bool Gen;
    public Gradient[] gradient = new Gradient[2];
    


    private void GeneratePlanet()
    {



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




        int PlanetCount;
        PlanetCount = (int)(Random.Range(1, 5));

        for (int i = 0; i < PlanetCount; i++)
        {
            GameObject planet = new GameObject();
            planet.transform.SetParent(this.transform);
            planet.AddComponent<CubeSphere2>();
            planet.AddComponent<RotateEarth>();
            planet.AddComponent<Rigidbody>();
            planet.GetComponent<Rigidbody>().useGravity = false;
            planet.GetComponent<Rigidbody>().isKinematic = true;
            planet.AddComponent<SphereCollider>();
            planet.GetComponent<SphereCollider>().radius = 1.05f;


            planet.transform.transform.Rotate(Random.Range(-45, 45), 0, Random.Range(-45, 45));
            planet.transform.position = planet.transform.position + new Vector3(30 * i + 50, 0, 0);
        }
    }








    void Update()
    {
        if (Gen == true)
        {
            GeneratePlanet();
            Gen = false;
        }
    }
}
