using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxe : MonoBehaviour
{
    private float length, startpos;
    GameObject cam;
    public float layer;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        cam = Camera.main.gameObject;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        float temp = (cam.transform.position.x * (1 - layer));
        float dist = (cam.transform.position.x * layer);

        transform.position = new Vector3(startpos + dist, transform.position.y , transform.position.z);

        if(Mathf.Abs(cam.transform.position.x - transform.position.x) > 25 && cam.transform.position.x > transform.position.x)
        {
            transform.position = new Vector3(transform.position.x + 50, transform.position.y, transform.position.z);
        }
        else if (Mathf.Abs(cam.transform.position.x - transform.position.x) > 25 && cam.transform.position.x < transform.position.x)
        {
            transform.position = new Vector3(transform.position.x - 50, transform.position.y, transform.position.z);
        }
    }
}
