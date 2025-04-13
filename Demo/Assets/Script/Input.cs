using UnityEngine;
using System.IO.Ports;

public class Input : MonoBehaviour
{
    SerialPort dataStream;
    public string serialPort = "COM3";  //port name
    public int baud = 9600;             //sets the communication rate

    private string receivedString;      //takes in value from Serial port
    Rigidbody moveableCube;             //to move the cube
    Transform transformCube;
    float prevJump;                     //keeps track of jump delta values

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
        if (dataStream.IsOpen)
        {
            receivedString = dataStream.ReadLine();
            float jumpY = float.Parse(receivedString);
            Debug.Log("Jump: "+ jumpY);
            if(jumpY> 0 && prevJump == 0)
            {
                moveableCube.AddForce(new Vector3(0, 5f, 0), ForceMode.Impulse);
            }

            //prevJump = jumpY;
            prevJump = jumpY;
        }
    }
}
