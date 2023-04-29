using UnityEngine;

public class motorbike_movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float rotSpeed;
    public Rigidbody2D pushUpRbRight;
    public Rigidbody2D pushUpRbLeft;
    public float pushupForce = 6f;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.Pause)
        {
            rb.Sleep();
            pushUpRbRight.Sleep();
            pushUpRbLeft.Sleep();
            enabled = false;
        }
        else
        {
            rb.WakeUp();
            pushUpRbRight.WakeUp();
            pushUpRbLeft.WakeUp();
            enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Movement to the right
        if(Input.GetKey("right") || Input.GetKey("a")) {
            rb.AddForce(new Vector3(10f,0f,0f));
            
        }
        
        //Movement to the left
        if(Input.GetKey("left") || Input.GetKey("d")) {
            rb.AddForce(new Vector3(-10f,0f,0f));
        }

        // Rotate to the right
        if(Input.GetKey("down") || Input.GetKey("s")) {
            //Reset velocity to 0
            if(pushUpRbLeft.velocity.y < 0f) {
                pushUpRbLeft.velocity = new Vector2(0f,0f);
            }

            // Add rotation velocity
            pushUpRbLeft.velocity += new Vector2(0f,0.07f);
        }else{
            // if we are not rotating the velocity should be equal to gravity
            pushUpRbLeft.velocity = new Vector2(0f,-9.8f);
        }

        //Rotate to the left, but only when we are not rotating to the right, because else the character will start to fly
        if((Input.GetKey("up") || Input.GetKey("a")) && !(Input.GetKey("down") || Input.GetKey("s"))) {
            //Reset velocity to 0
            if(pushUpRbRight.velocity.y < 0f) {
                pushUpRbRight.velocity = new Vector2(0f,0f);
            }
            
            // Add rotation velocity
            pushUpRbRight.velocity += new Vector2(0f,0.07f);
            
        }else{
            // if we are not rotating the velocity should be equal to gravity
            pushUpRbRight.velocity = new Vector2(0f,-9.8f);
        }


        // this next part clamps the rotation and movement velocity to their respective max value

        if(pushUpRbLeft.velocity.y > 3f) {
            pushUpRbLeft.velocity = new Vector2(0f,3f);
        }

        if(pushUpRbRight.velocity.y > 3f) {
            pushUpRbRight.velocity = new Vector2(0f,3f);
        }

        if(rb.velocity.x < -5f) {
            rb.velocity = new Vector2(-5f,0f);
        }else if(rb.velocity.x > 5f) {
            rb.velocity = new Vector2(5f,0f);
        }
        
    }
}
