using UnityEngine;

public class motorbike_movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float rotSpeed;
    public Rigidbody2D pushUpRb;


    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.Pause)
        {
            rb.Sleep();
            enabled = false;
        }
        else
        {
            rb.WakeUp();
            enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("right") || Input.GetKey("a")) {
            rb.AddForce(new Vector3(10f,0f,0f));
            
        }

        if(Input.GetKey("left") || Input.GetKey("d")) {
            rb.AddForce(new Vector3(-10f,0f,0f));
            // rb.velocity = new Vector2(-5f,0f);
        }

        // if(Input.GetKey("down")) {
        //     transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 100), rotSpeed);

        //     // rb.AddForce(new Vector3(0f,0.1f,0f));
        //     // rb.AddRelativeTorque(transform.forward * 1.0f, ForceMode.Impulse);
        //     // Quaternion deltaRotation = Quaternion.Euler(transform.forward * 1.0f * Time.fixedDeltaTime);
        //     // rb.MoveRotation(rb.rotation * deltaRotation);
        //     // rb.rotation += 1.0f;
        //     // rb.angularVelocity = transform.forward * 1.0f;    // spin around +Z at 1rad/sec
        //     // transform.Translate(transform.forward * 1.0f * Time.deltaTime, Space.World);
        //     // rb.angularDrag = 0.0f;
        // }

        // if(Input.GetKey("up")) {
        //     // transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -100), rotSpeed);

        //     // rb.angularVelocity = transform.forward * -1.0f;
        //     // rb.AddRelativeTorque(transform.forward * -1.0f, ForceMode.Impulse);
        //     // Quaternion deltaRotation = Quaternion.Euler(transform.forward * -1.0f * Time.fixedDeltaTime);
        //     // rb.MoveRotation(rb.rotation * deltaRotation);
        //     // rb.rotation += -1.0f;
        //     // transform.Translate(transform.forward * -1.0f * Time.deltaTime, Space.World);

        //     pushUpRb.AddForce(new Vector3(0f,0.4f,0f));
            
        // }

        if(rb.velocity.x < -5f) {
            rb.velocity = new Vector2(-5f,0f);
        }else if(rb.velocity.x > 5f) {
            rb.velocity = new Vector2(5f,0f);
        }
        
    }
}
