using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinParticle : MonoBehaviour {

    public GameObject[] winParticles;

    void Start()
    {
        foreach (GameObject gameObject in winParticles)
        {
            Instantiate(gameObject, 
                new Vector3(Random.Range(-14.0f, 14.0f), 
                    0, 
                    Random.Range(-6.0f, 4.0f)),      
                Quaternion.Euler(new Vector3(90.0f, 0f, 0f)));
        }
    }
}
