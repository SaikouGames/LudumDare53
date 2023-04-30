using UnityEngine;

public class motorbike_movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float rotSpeed;
    public Rigidbody2D pushUpRbRight;
    public Rigidbody2D pushUpRbLeft;
    public Transform pushUpRbRightTransform;
    public Transform pushUpRbLeftTransform;
    public detect_wheel_ground_contact wheelGroundContact;

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
        if(Input.GetKey("right") || Input.GetKey("d")) {
            rb.AddForce(new Vector3(5000f*Time.deltaTime,0f,0f));
            
        }
        
        //Movement to the left
        if(Input.GetKey("left") || Input.GetKey("a")) {
            rb.AddForce(new Vector3(-5000f*Time.deltaTime,0f,0f));
        }

        // Rotate to the right
        if(Input.GetKey("down") || Input.GetKey("s")) {
            var impulse = (-17 * Mathf.Deg2Rad) * 7000f*Time.deltaTime;
            rb.AddTorque(impulse);
        }else{
        }

        //Rotate to the left, but only when we are not rotating to the right, because else the character will start to fly
        if((Input.GetKey("up") || Input.GetKey("w")) && !(Input.GetKey("down") || Input.GetKey("s"))) {
            var impulse = (24 * Mathf.Deg2Rad) * 7000f*Time.deltaTime;
            rb.AddTorque(impulse);//7000f*Time.deltaTime);
            
        }else{

        }

        if(Input.GetKeyDown("space") && wheelGroundContact.isWheelGrounded) {
            rb.AddForce(new Vector2(0f,100000f*Time.deltaTime));
        }


        // this next part clamps the rotation and movement velocity to their respective max value

        if((pushUpRbLeft.velocity.y + pushUpRbLeft.velocity.x) > 2f) {
            pushUpRbLeft.velocity = new Vector2(pushUpRbRightTransform.up.x,pushUpRbRightTransform.up.y) * 2f;//new Vector2(0f,3f);
        }

        if((pushUpRbRight.velocity.y + pushUpRbRight.velocity.x) > 2f) {
            pushUpRbRight.velocity = new Vector2(pushUpRbRightTransform.up.x,pushUpRbRightTransform.up.y) * 2f;//new Vector2(0f,3f);
        }

        if(rb.velocity.x < -5f) {
            rb.velocity = new Vector2(-5f,0f);
        }else if(rb.velocity.x > 5f) {
            rb.velocity = new Vector2(5f,0f);
        }
        
    }
}
