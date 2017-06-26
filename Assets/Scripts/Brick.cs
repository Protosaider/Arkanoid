using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    
    public GameObject destroyParticles;

    void OnCollisionEnter(Collision other) 
    {
        Instantiate(destroyParticles, transform.position, Quaternion.identity);
        GameManager.instance.DestroyBrick();
        AudioManager.instance.DestroyBrickSound();
        Destroy(gameObject);
    }
}
