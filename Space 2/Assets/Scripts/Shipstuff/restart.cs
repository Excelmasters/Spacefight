using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public GameObject ss;
    public Material spherematerial;
    public GameObject prefab;
    public GameObject Projectile;
    public GameObject UFO;
    public VisualEffect visual;


    // Update is called once per frame
    private void Start()
    {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        
    }
}
