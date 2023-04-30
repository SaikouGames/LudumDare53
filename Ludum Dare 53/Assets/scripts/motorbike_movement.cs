using UnityEngine;

public class motorbike_movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float rotSpeed;
    // public Rigidbody2D pushUpRbRight;
    // public Rigidbody2D pushUpRbLeft;
    // public Transform pushUpRbRightTransform;
    // public Transform pushUpRbLeftTransform;
    public detect_wheel_ground_contact wheelGroundContact;
    public float maxAngularVelocity = 40f;
    public float rotationStrength = 200000f;

    public bool tech = false;
    public WheelJoint2D joint;
    public WheelJoint2D joint2;

    public float Speed = 1000;
    public float torque = 40;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.Pause)
        {
            rb.Sleep();
            // pushUpRbRight.Sleep();
            // pushUpRbLeft.Sleep();
            enabled = false;
        }
        else
        {
            rb.WakeUp();
            // pushUpRbRight.WakeUp();
            // pushUpRbLeft.WakeUp();
            enabled = true;
        }

        //joint = GetComponent<WheelJoint2D>();
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tech)
        {
            //Movement to the right
            if (Input.GetKey("right") || Input.GetKey("d"))
            {
                rb.AddForce(new Vector3(50000f * Time.deltaTime, 0f, 0f));

            }

            //Movement to the left
            if (Input.GetKey("left") || Input.GetKey("a"))
            {
                rb.AddForce(new Vector3(-50000f * Time.deltaTime, 0f, 0f));
            }

            // Rotate to the right
            if (Input.GetKey("k"))
            {//Input.GetKey("down") || Input.GetKey("s")) {
                var impulse = (-24 * Mathf.Deg2Rad) * rotationStrength * Time.deltaTime;
                rb.AddTorque(impulse);
                // rb.rotation -= rb.rotation*rotSlowDownFactor*Time.deltaTime + (addRotFactor+Time.deltaTime);
            }
            else
            {
            }

            //Rotate to the left, but only when we are not rotating to the right, because else the character will start to fly
            if (Input.GetKey("l"))
            {//(Input.GetKey("up") || Input.GetKey("w")) && !(Input.GetKey("down") || Input.GetKey("s"))) {
                var impulse = (24 * Mathf.Deg2Rad) * rotationStrength * Time.deltaTime;
                rb.AddTorque(impulse);//7000f*Time.deltaTime);
                                      // rb.rotation += rb.rotation*rotSlowDownFactor*Time.deltaTime + (addRotFactor+Time.deltaTime);

            }
            else
            {

            }

            if (rb.angularVelocity > maxAngularVelocity)
            {
                rb.angularVelocity = maxAngularVelocity;
            }

            if (rb.angularVelocity < maxAngularVelocity * -1)
            {
                rb.angularVelocity = maxAngularVelocity * -1;
            }

            if (Input.GetKeyDown("space") && wheelGroundContact.isWheelGrounded)
            {
                rb.AddForce(new Vector2(0f, 100000f * Time.deltaTime));
            }


            // this next part clamps the rotation and movement velocity to their respective max value

            // if((pushUpRbLeft.velocity.y + pushUpRbLeft.velocity.x) > 2f) {
            //     pushUpRbLeft.velocity = new Vector2(pushUpRbRightTransform.up.x,pushUpRbRightTransform.up.y) * 2f;//new Vector2(0f,3f);
            // }

            // if((pushUpRbRight.velocity.y + pushUpRbRight.velocity.x) > 2f) {
            //     pushUpRbRight.velocity = new Vector2(pushUpRbRightTransform.up.x,pushUpRbRightTransform.up.y) * 2f;//new Vector2(0f,3f);
            // }

            if (rb.velocity.x < -5f)
            {
                rb.velocity = new Vector2(-5f, rb.velocity.y);
            }
            else if (rb.velocity.x > 5f)
            {
                rb.velocity = new Vector2(5f, rb.velocity.y);
            }
        }
        else
        {
            JointMotor2D motor = new JointMotor2D();
            motor.motorSpeed = 0;
            if (Input.GetKey("right") || Input.GetKey("d"))
            {
                motor.motorSpeed = -Speed;
            }
            if (Input.GetKey("left") || Input.GetKey("a"))
            {
                motor.motorSpeed = Speed;
            }
            motor.maxMotorTorque = torque;
            joint.motor = motor;
            joint2.motor = motor;

            // Rotate to the right
            if (Input.GetKey("l"))
            {//Input.GetKey("down") || Input.GetKey("s")) {
                var impulse = (-24 * Mathf.Deg2Rad) * rotationStrength * Time.deltaTime;
                rb.AddTorque(impulse);
                // rb.rotation -= rb.rotation*rotSlowDownFactor*Time.deltaTime + (addRotFactor+Time.deltaTime);
            }
            else
            {
            }

            //Rotate to the left, but only when we are not rotating to the right, because else the character will start to fly
            if (Input.GetKey("k"))
            {//(Input.GetKey("up") || Input.GetKey("w")) && !(Input.GetKey("down") || Input.GetKey("s"))) {
                var impulse = (24 * Mathf.Deg2Rad) * rotationStrength * Time.deltaTime;
                rb.AddTorque(impulse);//7000f*Time.deltaTime);
                                      // rb.rotation += rb.rotation*rotSlowDownFactor*Time.deltaTime + (addRotFactor+Time.deltaTime);

            }
        }
        
    }
}
