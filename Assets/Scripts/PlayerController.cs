using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  
    public float playerSpeed;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //Clamp - to make a border for platform.
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + (moveHorizontal * playerSpeed),
                -22.4f, 
                22.4f),
            transform.position.y, 
            transform.position.z);

    }

    void OnCollisionEnter()
    {
        AudioManager.instance.PlayerHitSound();
    }
}
