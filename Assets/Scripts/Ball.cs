using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    
    public float initialVelocity = 600f;
    private Rigidbody rb;
 
    private bool ballInGame = false;
	
	void Awake() 
    {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update() 
    {
        if (Input.GetButtonDown("Jump") && ballInGame == false)
        {
            transform.parent = null;
            ballInGame = true;
            //whether physics affects rigidbody
            rb.isKinematic = false;
            float x = Mathf.Clamp(Random.Range(-1.0f, 1.0f), -0.8f, 0.8f);
            Vector3 push = new Vector3(x, 0, 1.0f - Mathf.Abs(x)) 
                * initialVelocity;
            
            rb.AddForce(push);        

            AudioManager.instance.LaunchBallSound();
        } 
	}
}
