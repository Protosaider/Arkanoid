using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    
    public AudioClip hitSound1;
    public AudioClip hitSound2;
    private AudioSource source;

	// Use this for initialization
	void Awake() 
    {
        source = GetComponent<AudioSource>();
	}
	
    void OnCollisionEnter(Collision other) 
    {
        if (Random.value < 0.5f)
        {
            source.PlayOneShot(hitSound1, 1.0f);
        } else
        {
            source.PlayOneShot(hitSound2, 1.0f);
        }
    }
}
