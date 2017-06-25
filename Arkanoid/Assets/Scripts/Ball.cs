using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Vector3 startPosition;
    public float initialVelocity = 600f;
    private Rigidbody rb;
    //private Vector3 push;

    private bool ballInGame = false;
	
	void Awake() 
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update() 
    {
        Debug.Log("Velocity: " + rb.velocity + " angular: " + rb.angularVelocity);
        //need to call GetButtonDown from the Update function
        //if (Input.GetKeyDown(KeyCode.Space) && ballInGame == false)
        if (Input.GetButtonDown("Jump") && ballInGame == false)
        {
            transform.parent = null;
            ballInGame = true;
            //whether physics affects rigidbody
            rb.isKinematic = false;
            float x = Mathf.Clamp(Random.Range(-1.0f, 1.0f), -0.8f, 0.8f);
            Vector3 push = new Vector3(x, 0, 1.0f - Mathf.Abs(x)) * initialVelocity;
            rb.AddForce(push);        
            //rb.velocity = Vector3.left;
        } else 
            if (Input.GetButtonDown("Jump") && ballInGame == true)
            {
                transform.parent = null;
                ballInGame = false;
                //whether physics affects rigidbody
                rb.isKinematic = false;
                transform.position = startPosition;
                //rb.AddForce(-push);
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
	}
}
