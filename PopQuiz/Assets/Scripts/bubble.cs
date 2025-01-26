using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class main : MonoBehaviour
{
    // Game vals
    public int number = 99;
    //public Rigidbody rb;
    //public float forceAmount = 10;

    // Ambient movement options
    public float floatSpeed = 1.0f;
    public float floatRange = 0.5f;
    public float moveSpeed = 0.5f;
    public float moveRange = 1.0f;

    public Transform bubbleNum;
    public GameObject bubbleObj;
    
    // Display
    //public displayed billboard text
    //private find the canvas and text element always on this GameObject and feed it numbers to display

    //public size of the bubble relative to its number
    private Vector3 startPosition; // Used for initial instantiation; survey play field

    void Start()
    {
        
        startPosition = transform.position;
        number = Random.Range(0, 30);


        //have the ball drop to show things are running
        //rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);
        TextMeshProUGUI bubbleText = GetComponentInChildren<TextMeshProUGUI>();
        if (bubbleText != null)
        {
            bubbleText.text = number.ToString();
            Debug.Log("Found TMP text: " + bubbleText.text);
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found!");
        }
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

    void OnTriggerEnter(Collider other)
    {
        // Check if the other object is a bubble
        main otherBubble = other.GetComponent<main>();
        if (otherBubble != null)
        {
            MergeBubbles(otherBubble);
        }
    }

    void MergeBubbles(main otherBubble)
    {
        // Add the numbers of both bubbles
        number += otherBubble.number;

        // Update the UI to display the new number
        TextMeshProUGUI textObject = GetComponentInChildren<TextMeshProUGUI>();
        if (textObject != null)
        {
            textObject.text = number.ToString();
        }

        // Destroy the other bubble
        Destroy(otherBubble.gameObject);

        Debug.Log("Bubbles merged! New number: " + number);
    }

    void OnMouseDrag()
    {
        // Get mouse position in screen space
        Vector3 mousePos = Input.mousePosition;

        // Use the object's existing Z-depth
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;

        // Convert screen position to world space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        // Move the object to the calculated world position
        transform.position = worldPosition;
    }




}

