//Moves player
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    Vector3 initialPosition;
    bool isGrounded = false;
    public Vector3 speed = new Vector3(5.0f, 0.0f, 0.0f);
    public Vector3 jump = new Vector3( 0.0f, 10.0f, 0.0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.linearVelocity = speed;
        rb.AddForce(speed, ForceMode.VelocityChange);

        //if it falls off the ground, resets to initial point
        if(rb.transform.position.y < 0.0f)
        {
            this.rb.transform.position = initialPosition;
        }
    }

    //If falls on the ground, resets back to square 1
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            this.rb.transform.position = initialPosition;
        }
    }

    //To make the ball jump
    public void onJump()
    {
        if(isGrounded)
        {
            rb.AddForce(jump, ForceMode.Impulse);
            isGrounded= false;
        }
    }

    //Toggles between whether the player is jumping or not
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerGround"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerGround"))
        {
            isGrounded = false;
        }
    }
}
