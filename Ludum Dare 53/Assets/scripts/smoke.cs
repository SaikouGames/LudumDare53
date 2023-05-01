using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x + 0.0003f, transform.localScale.y + 0.0003f, transform.localScale.z);
        transform.Rotate(new Vector3(0,0,0.7f));
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.001f, transform.position.z);
        if(transform.localScale.x > 0.13)
        {
            Destroy(this);
        }
    }
}
