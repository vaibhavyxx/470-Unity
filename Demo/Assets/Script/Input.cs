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
        //Prints out the values from arduino to the consolea
        receivedString = dataStream.ReadLine();
        //Debug.Log(receivedString);
        //Parses values into an array
        //string[] substrings = receivedString.Split(',');
        float newY = float.Parse(receivedString);

        //if (substrings.Length >= 1)
        {
            //Debug.Log(substrings[0]);                         //prints Hi
            //float newY = float.Parse(substrings[1]);            //takes mapped value from arduino
            Debug.Log("newY: :"+ newY);
            //Moves the cube
            Vector3 targetPosition = new Vector3(transformCube.position.x, newY, transformCube.position.z);
            transformCube.position = Vector3.Lerp(transformCube.position, targetPosition, Time.deltaTime * 5.0f);
                //new Vector3(this.transform.position.x, newY, transform.position.z);

        }
        dataStream.ReadExisting();
    }
}
