using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    // Game vals
    public uint number = 99;
    //public Rigidbody rb;
    //public float forceAmount = 10;

    // Ambient movement options
    public float floatSpeed = 1.0f;
    public float floatRange = 0.5f;
    public float moveSpeed = 0.5f;
    public float moveRange = 1.0f;

    // Display
    //public displayed billboard text
    //private find the canvas and text element always on this GameObject and feed it numbers to display
    
    //public size of the bubble relative to its number
    private Vector3 startPosition; // Used for initial instantiation; survey play field

    void Start()
    {
        startPosition = transform.position;
        
        //have the ball drop to show things are running
        //rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);
    }
    void Update(){
         // Floating effect
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatRange;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Random movement
        float newX = startPosition.x + Mathf.PerlinNoise(Time.time * moveSpeed, 0) * moveRange - moveRange / 2;
        float newZ = startPosition.z + Mathf.PerlinNoise(0, Time.time * moveSpeed) * moveRange - moveRange / 2;
        transform.position = new Vector3(newX, newY, newZ);
        
        // Interaction layer
        if (Input.GetMouseButton(0)){
            Vector3 mousePos = Input.mousePosition;
            Vector3 wantedPos = transform.position;
            //Debug.Log(Input.mousePosition.y);
            wantedPos.y=Input.mousePosition.y / Screen.height;
            transform.position = wantedPos;
        }
    }
}