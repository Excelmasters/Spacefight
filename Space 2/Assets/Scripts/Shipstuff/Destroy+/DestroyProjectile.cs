using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    public float DestTime = 5;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time >= DestTime)
        {
            Debug.Log("Destroy");
            Destroy(this.gameObject);
        }
    }
}
