using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public int lives;
    public int score;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public Text scoreText;

	void Start () {
	    lives = 3;
	}
    
	void Update () {
	    UpdateScore();
        UpdateLives();
	}

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateLives()
    {
        switch(lives){
            case 3:
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(true);
                break;
            case 2:
                life1.SetActive(false);
                life2.SetActive(true);
                life3.SetActive(true);
                break;
            case 1:
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(true);
                break;
            case 0:
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(false);
                //GameOver();
                break;
        }
    }
}