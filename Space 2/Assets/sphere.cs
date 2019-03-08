using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;


public class sphere : MonoBehaviour
{

    public VisualEffect visual;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.AddComponent<VisualEffect>().visualEffectAsset = visual.visualEffectAsset;
    }


}
