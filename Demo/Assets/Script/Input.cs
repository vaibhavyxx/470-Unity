using UnityEngine;
using System.IO.Ports;

public class Input : MonoBehaviour
{
    SerialPort dataStream;
    public string serialPort = "COM3";  //port name
    public int baud = 9600;             //sets the communication rate

    private string receivedString;      //takes in value from Serial port
    Rigidbody moveableCube;             //to move the cube
    float prevJump;                     //keeps track of jump delta values

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveableCube = GetComponent<Rigidbody>();

        //Opens the port to get values
        dataStream = new SerialPort(serialPort, baud);
        dataStream.Open();
    }

    // Update is called once per frame
    void Update()
    {
        //to move the ball
       // moveableCube.linearVelocity = speed * Vector3.right;

        try
        {
            if (dataStream.IsOpen)
            {
                receivedString = dataStream.ReadLine();
                //string[] values = receivedString.Split(',');

                float jumpY = float.Parse(receivedString);  
                Debug.Log("Jump: " + jumpY);

                //for jumping
                if (jumpY > 10)
                {
                    moveableCube.AddForce(new Vector3(0, 2f, 0), ForceMode.Impulse);
                }
                prevJump = jumpY;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("Serial read error: " + e.Message);
        }
        
    }
}
