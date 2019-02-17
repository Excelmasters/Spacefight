using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class SunColor : MonoBehaviour
{
    public bool start;
    public VisualEffect sun;
    public  Gradient gradient;

    void OnValidate()
    {
        GradientColorKey[] colorKey = new GradientColorKey[(int)Random.Range(3, 7)];
        for (int i = 0; i < colorKey.Length; i++)
        {
            colorKey[i].time = Random.Range(0f, 1f);
            colorKey[i].color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255)) / 250;
        }
        GradientAlphaKey[] alphaKey = new GradientAlphaKey[0];
        gradient.SetKeys(colorKey, alphaKey);

        sun = GetComponent<VisualEffect>();
        sun.SetGradient(0, gradient);



    }

}
