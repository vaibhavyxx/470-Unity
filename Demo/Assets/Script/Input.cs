using UnityEngine;
using System.IO.Ports;

public class Input : MonoBehaviour
{
    SerialPort dataStream;
    public string serialPort = "COM3";  //port name
    public int baud = 9600;             //sets the communication rate

    private string receivedString;      //takes in value from Serial port
    public Transform moveableCube;      //to move the cube

    float prevX = 0.0f;                 //previous value

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        string[] substrings = receivedString.Split(',');
       
        if(substrings.Length > 2)
        {
            //Debug.Log(substrings[0]);                         //prints Hi
            float newX = float.Parse(substrings[2]);            //takes mapped value from arduino
            //newX = newX / 100.0f;                             //scales it to get decimal precision
            float deltaX = (newX - prevX);
            Debug.Log("Delta X: "+ deltaX);

            //Moves the cube
            moveableCube.Translate(deltaX * Time.deltaTime, 0, 0);
            prevX = newX;
        }
        dataStream.ReadExisting();
    }
}
