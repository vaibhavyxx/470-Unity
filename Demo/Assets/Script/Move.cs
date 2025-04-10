//Moves player
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 speed = new Vector3(5.0f, 0.0f, 0.0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.linearVelocity = speed;
        rb.AddForce(speed, ForceMode.VelocityChange);
    }
}
