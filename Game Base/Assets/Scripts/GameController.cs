using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public int lives; //Setting this value in the inspector before playing will do nothing. It is set in Start();
    public int score; //Same as lives
    public int maxLives; //If we choose to have a way gain lives, which I don't reccomend
    public float spawnX; //how far to the right to instantiate enemies (This should be off the screen and then some)
    public float spawnDelayMin; //Min time between spawning enemies
    public float spawnDelayMax; //Max time between spawning enemies

    public GameObject[] enemies; //Add all enemy prefabs to this array
    public GameObject life1; //Holds refrences to life GUI display at top right
    public GameObject life2;
    public GameObject life3;
    public Text scoreText; //Reference to the score display at top left

    private bool line4; //Bool of which lines are active.
    private bool line3;
    private bool line1; //the middle line will ALWAYS be active. This leaves a min of 3 lines at any time, and a max of 5.
    private bool line0;

	void Start () {
	    lives = 3; //Starting lives
        score = 0; //Starting score
        line4 = true; //Every new game starts with all 5 wires
        line3 = true; //Cause yolo that's why
        line1 = true;
        line0 = true;
        StartCoroutine(SpawnEnemies()); //Start spawn loop
	}
    
	void Update () {
	    UpdateScore(); //This is temporary. In the future, only call these function when their values are changed via AddScore();
        UpdateLives(); //Same as above, but with AddLives();
	}


    void MapGenerator () { //Generates the next segment of map, specifically the active wires, webs, powerups, and wire frays.

        int wires = Random.Range(3,6); //Determines number of wires, equally weighted. Scale diffculty with time?

        if (wires==5) { //Determine which lines are active, randomly
            line4 = true;
            line3 = true;
            line1 = true;
            line0 = true;
        }

        if (wires==4) {

            switch(Random.Range(0,2)){
            case 1: //Cuts off top wire
                line4 = false;
                line3 = true;
                line1 = true;
                line0 = true;
                break;
            case 0: //Cuts off bottom wire
                line4 = true;
                line3 = true;
                line1 = true;
                line0 = false;
                break;
            }
        }

            if (wires==3) {

            switch(Random.Range(0,3)){
            case 2: //Cuts off top 2 wires
                line4 = false;
                line3 = false;
                line1 = true;
                line0 = true;
                break;
            case 1: //Allows for middle 3 to be active, cutting off both top and bottom
                line4 = false;
                line3 = true;
                line1 = true;
                line0 = false;
                break;
            case 0: //Cuts off bottom two wires
                line4 = true;
                line3 = true;
                line1 = false;
                line0 = false;
                break;
            }
        }

        //Proceed to generate wires for these lines.
        //Lines should be 2 meters (unity units are meters) apart vertically. Use the prefabs.
        //Include random webs and frays at random intervals.
        //Prevent stacking, so that you can't get a solid collumn of frays, making it impossible to corss safely.
    }


    IEnumerator SpawnEnemies()
    {
        GameObject enemy; //reference to enemy that we will be instantiating in
        int spawnYmax;
        int spawnYmin;
        enemy = enemies[Random.Range(0, enemies.Length)]; //Pick an enemy at random, all at the same weight
        if (line4){ //determine the possible y values for spawning enemies
            spawnYmax = 2;
        }
        else if (line3){
            spawnYmax = 1;
        }
        else {
            spawnYmax = 0;
        }
        if (line0){
            spawnYmin = -2;
        }
        else if (line1){
            spawnYmin = -1;
        }
        else {
            spawnYmin = 0;
        }
        Vector3 spawnPosition = new Vector3(spawnX, 2*Random.Range(spawnYmin,spawnYmax), 0); //Determine position to spawn at
        Instantiate(enemy, spawnPosition, Quaternion.identity); //Spawn enemy


        yield return new WaitForSeconds(Random.Range(spawnDelayMin,spawnDelayMax)); //Wait random time before spawning another enemy
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

    public void AddLives(int newLifeValue)
    {
        lives += newLifeValue;
        UpdateLives();
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