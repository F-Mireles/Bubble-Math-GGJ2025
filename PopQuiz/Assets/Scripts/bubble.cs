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

    private Vector3 startPosition; // Used for initial instantiation; survey play field
    private bool isDragging = false;

    public GameObject BigBubble;
    Vector3 mousePosition;

    // Display
    //public displayed billboard text
    //private find the canvas and text element always on this GameObject and feed it numbers to display

    //public size of the bubble relative to its number
 
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
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found!");
        }
    }
    void Update(){
         // Floating effect
         if(!isDragging)
        {
             float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatRange;
             transform.position = new Vector3(transform.position.x, newY, transform.position.z);
         }
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the other object is a bubble

        main otherBubble = other.GetComponent<main>();
        if (otherBubble != null)
        {
            if(number >= otherBubble.number)
            {
                MergeBubbles(otherBubble);
            }
           
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

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    void OnMouseDrag()
    {
        isDragging = true;
        // Move the object to the calculated world position
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }

    void OnMouseUp()
    {
        isDragging = false;
        startPosition = transform.position; // Update the floating origin after dragging
    }

}

