//Moves player
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    Transform transform;
    Vector3 initialPosition;
    public float speed = -5.0f;
    GameObject text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        initialPosition = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            this.transform.position = initialPosition;
            text.SetActive(false);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            //rb.linearVelocity = Vector3.zero;
        }
    }


}
