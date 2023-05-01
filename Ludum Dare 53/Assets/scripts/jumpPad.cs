using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPad : MonoBehaviour
{
    public Rigidbody2D rb;

    bool ready = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && ready)
        {
            Debug.Log("d");
            rb.AddForceAtPosition(new Vector2(0f, 800f), new Vector2(transform.position.x, transform.position.y));
            ready = false;
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        ready = true;
    }
}
