using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControle : MonoBehaviour
{
    public GameObject ss;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        ss = GameObject.Find("Spaceship");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(ss.transform);
        rb.

    }
}
