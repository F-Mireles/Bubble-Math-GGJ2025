using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public Rigidbody rb;
    public float forceAmount = 10;

    void Start()
    {
        //have the ball drop to show things are running
        rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);
    }
    void Update(){
        //just a quick light interaction
        if (Input.GetMouseButton(0)){
            Vector3 mousePos = Input.mousePosition;
            Vector3 wantedPos = transform.position;
            //Debug.Log(Input.mousePosition.y);
            wantedPos.y=Input.mousePosition.y / Screen.height;
            transform.position = wantedPos;
        }
    }
}