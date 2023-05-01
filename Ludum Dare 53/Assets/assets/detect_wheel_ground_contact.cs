using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect_wheel_ground_contact : MonoBehaviour
{
    public bool isWheelGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionExit2D(Collider2D other) {
        if (other.gameObject.tag == "Ground") {
            isWheelGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Ground") {
            isWheelGrounded = true;
        }
    }

}
