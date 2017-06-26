using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour {

    public float destroyTime = 0.7f;
	// Use this for initialization
	void Start() 
    {
        Destroy(gameObject, destroyTime);
	}
	
}
