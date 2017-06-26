using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //private Rigidbody rb;
    public float playerSpeed;
    //public Vector3 startPosition;
	// Use this for initialization
	void Start() 
    {
        //rb = GetComponent<Rigidbody>();
	}
	
    void FixedUpdate()
    {
        //Debug.Log(Mathf.Clamp(7, 1, 5));
        float moveHorizontal = Input.GetAxis("Horizontal");
        //Clamp - to make a border for platform.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + (moveHorizontal * playerSpeed), -22.4f, 22.4f), transform.position.y, transform.position.z);

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f);
        //rb.AddForce(movement * playerSpeed, ForceMode.Force);
        /*if (Input.GetKeyDown(KeyCode.Space)) 
        {
            transform.position = startPosition;
        }*/
    }
}
