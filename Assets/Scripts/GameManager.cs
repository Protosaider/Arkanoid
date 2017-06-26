using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int lifeCount = 3;
    public int bricksCount = 55;
    public int scoreCount = 0;
    public float resetDelay = 1.5f;

    private string ballTypeName = "Ball"; //___for find___

    public Text lifeCountText;
    public Text scoreCountText;

    public GameObject youWon;
    public GameObject youLose;
    public GameObject manual;

    public GameObject destructibleBlocksPrefab;
    public GameObject playerDestroyParticles;

    public GameObject player;

    private GameObject clonePlayer;

    public static GameManager instance = null; //for Singletone

    public AudioClip brickSound;
    public AudioClip winSound;
    private AudioSource source;

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
        Setup();
        ShowManual();
        source = GetComponent<AudioSource>();
	}

    //ONLY FOR EXIT
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void ShowManual()
    {
        manual.SetActive(true);
        Invoke("CloseManual", resetDelay);
    }

    void CloseManual()
    {
        manual.SetActive(false);
    }

    void Setup() //custom function
    {
        //clone the object and return the clone
        ResetPlayer();
        Instantiate(destructibleBlocksPrefab, transform.position, Quaternion.identity);
        //Instantiate(destructibleBlocksPrefab);
    }
	
    void Reset() 
    {
        Time.timeScale = 1f;
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    void ResetPlayer() 
    {
        clonePlayer = Instantiate(player, player.transform.position, Quaternion.identity) as GameObject;
    }

    //void IsGameOver()
    void CheckGameOver()
    {
        if (bricksCount < 1) 
        {
            youWon.SetActive(true);
            WinSound();
            Time.timeScale = 0.5f; //use for slow motion
            Invoke("Reset", resetDelay); //invoke method with delay
        }

        if (lifeCount < 1)
        {
            youLose.SetActive(true);
            Time.timeScale = 0.5f; //use for slow motion
            Invoke("Reset", resetDelay); //invoke method with delay
        }
    }   

    public void LoseLife() //in Floor
    {
        lifeCount--;
        lifeCountText.text = "" + lifeCount;
        scoreCount = 0;
        scoreCountText.text = "" + scoreCount;
        Instantiate(playerDestroyParticles, clonePlayer.transform.position, Quaternion.identity); //don't needed as GameObject
        Destroy(GameObject.Find(ballTypeName)); //___kluge?___
        Destroy(clonePlayer);
        Invoke("ResetPlayer", resetDelay);
        CheckGameOver();
    }

    public void DestroyBrick() //to call from brick.cs
    {
        bricksCount--;
        scoreCount++;
        scoreCountText.text = "" + scoreCount;
        CheckGameOver();
        DestroyBrickSound();
    }

    void DestroyBrickSound()
    {
        source.PlayOneShot(brickSound, 0.9f);
    }

    void WinSound()
    {
        source.PlayOneShot(winSound, 1.0f);
    }
}
