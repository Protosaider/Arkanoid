using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    public AudioClip loseSound;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collider)
    {
        source.PlayOneShot(loseSound, 1.0f);
        GameManager.instance.LoseLife();
    }
}
