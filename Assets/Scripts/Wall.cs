using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    void OnCollisionEnter(Collision other) 
    {
        AudioManager.instance.HitWallSound();
    }
}
