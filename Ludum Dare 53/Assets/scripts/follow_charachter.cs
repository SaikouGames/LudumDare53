using UnityEngine;

public class follow_charachter : MonoBehaviour
{

    public Transform playerTransform;
    public float lerpSpeed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerTransform.position.x,playerTransform.position.y,-10f), lerpSpeed);   
    }
}
