using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip hitSound;      //playerController
    public AudioClip brickSound;    //GameManager -> Brick
    public AudioClip winSound;      //GameManager
    public AudioClip loseSound;     //Floor
    public AudioClip launchSound;   //Ball
    public AudioClip hitWallSound1; //Wall
    public AudioClip hitWallSound2; //Wall

    public static AudioManager instance = null; //for Singletone
    private AudioSource source;
    private bool endGame;
	// Use this for initialization
	void Start() 
    {
        if (instance == null)
        {
            instance = this; 
        } else if (instance != this)
        {
            Destroy(gameObject); //use to prevent duplication of Manager
        }
        source = GetComponent<AudioSource>();
	}
	
    public void PlayerHitSound()
    {
        if (!IsGameEnded())
        {
            source.PlayOneShot(hitSound, 1.0f);
        }
    }

    public void DestroyBrickSound()
    {
        if (!IsGameEnded())
        {
            source.PlayOneShot(brickSound, 0.9f);
        }
    }

    public void WinSound()
    {
        if (!IsGameEnded())
        {
            source.PlayOneShot(winSound, 1.0f);
        }
    }

    public void HitWallSound()
    {
        if (IsGameEnded())
        {
            return;
        }

        if (Random.value < 0.5f)
        {
            source.PlayOneShot(hitWallSound1, 1.0f);
        } else
        {
            source.PlayOneShot(hitWallSound2, 1.0f);
        }
    }

    public void LoseSound()
    {
        if (!IsGameEnded()) {
            source.PlayOneShot(loseSound, 1.0f);
        }
    }

    public void LaunchBallSound()
    {
        source.PlayOneShot(launchSound, 1.0f);
    }

    bool IsGameEnded()
    {
        if (GameManager.instance.EndGame) 
        {
            return true;
        } else
        {
            return false;
        }
    }

}
