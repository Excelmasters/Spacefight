using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class EnemyControle : MonoBehaviour
{
    public GameObject ss;
    public Rigidbody rb;
    public int health;
    public VisualEffect visu;
    public float time;
    private bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
        time = 0;
        ss = GameObject.Find("Spaceship");
        rb = gameObject.GetComponent<Rigidbody>();
        health = 1;
        visu = GameObject.Find("Gamemanager").transform.GetChild(0).GetComponent<VisualEffect>() ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health < 1) {
            if(spawned == false)
            {
                spawned = true;
                GameObject visualeffect = new GameObject();

                visualeffect.AddComponent<VisualEffect>().visualEffectAsset = visu.visualEffectAsset;
                visualeffect.GetComponent<VisualEffect>().transform.localScale = new Vector3(5, 5, 5);
                visualeffect.transform.position = gameObject.transform.position;


            }
            for(int i = 0; i < 2; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
            }
            time += Time.deltaTime;
            if (time > 3)
            {
                Destroy(gameObject);
            }



        }
        if (health > 0)
        {
            transform.LookAt(ss.transform);
            transform.position = Vector3.MoveTowards(transform.position, ss.transform.position, Time.deltaTime * 10);
        }

    }
}
