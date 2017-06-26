using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
 
    void OnTriggerEnter(Collider collider)
    {
        GameManager.instance.LoseLife();
    }
}
