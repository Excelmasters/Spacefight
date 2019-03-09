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
    private AudioSource[] audiosource;
    private AudioSource sound0;
    private AudioSource sound1;
    private AudioSource sound2;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audiosource = new AudioSource[2];
        spawned = false;
        time = 0;
        ss = GameObject.Find("Spaceship");
        rb = gameObject.GetComponent<Rigidbody>();
        health = 1;
        visu = GameObject.Find("Gamemanager").transform.GetChild(0).GetComponent<VisualEffect>() ;
        audiosource = GetComponents<AudioSource>();
        sound0 = audiosource[0];
        sound1 = audiosource[1];
        sound2 = audiosource[2];
    }

    // Update is called once per frame


    void OnCollisionEnter(Collision collideinfo)
    {
        if (collideinfo.collider.tag == "Core")
        {
            Destroy(collideinfo.collider.gameObject.transform.parent.gameObject);
            sound2.Play();


        }

        
    }

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


                sound1.Play();
                sound0.Play();
                

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
        else
        {
            if (ss.gameObject != null)
            {
                transform.LookAt(ss.transform);
                transform.position = Vector3.MoveTowards(transform.position, ss.transform.position, Time.deltaTime * 10);
            }
        }

    }
}
