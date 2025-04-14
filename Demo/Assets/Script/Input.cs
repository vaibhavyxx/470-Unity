using UnityEngine;
using System.IO.Ports;

public class Input : MonoBehaviour
{
    SerialPort dataStream;
    public string serialPort = "COM3";  //port name
    public int baud = 9600;             //sets the communication rate
    public float speed = 1.0f;

    private string receivedString;      //takes in value from Serial port
    Rigidbody moveableCube;             //to move the cube
    Transform transformCube;
    float prevJump;                     //keeps track of jump delta values
    Vector3 lastPosition;               //to stop

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveableCube = GetComponent<Rigidbody>();
        transformCube = GetComponent<Transform>();

        //Opens the port to get values
        dataStream = new SerialPort(serialPort, baud);
        dataStream.Open();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (dataStream.IsOpen)
            {
                receivedString = dataStream.ReadLine();
                string[] values = receivedString.Split(',');

                float jumpY = float.Parse(values[0]);
                float move = float.Parse(values[1]);    
                Debug.Log("Jump: " + jumpY + ", Coordinates RAW: " + values[1] + ", Coordinates: " + values[2]);

                //for jumping
                if (jumpY > 0 && prevJump == 0)
                {
                    moveableCube.AddForce(new Vector3(0, 5f, 0), ForceMode.Impulse);
                }

                //If move value is under 5 - goes back
                // 5 -7 -stops
                // 7 and above- goes foward
                /*if(move < 5)
                {
                    moveableCube.linearVelocity = lastPosition;
                }
                else if(move >= 5 && move > 10)
                {
                    moveableCube.linearVelocity += new Vector3(lastPosition.x, lastPosition.y, -move);
                }
                else
                {
                    moveableCube.linearVelocity += new Vector3(lastPosition.x, lastPosition.y, +move);
                }*/
                
                

                //prevJump = jumpY;
                prevJump = jumpY;
                lastPosition = transform.position;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("Serial read error: " + e.Message);
        }
        
    }
}
