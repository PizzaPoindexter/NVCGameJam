using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController controller; //Public reference to the game controller for easier access from other objects.

    public int lives; //Setting this value in the inspector before playing will do nothing. It is set in Start();
    public float score; //Same as lives
    public float distance; //Total distance traveled, same as lives
    public float time; //In-game time passed, same as lives
    public float distPoints; //Multiplier of points granted by distance travelled
    public float startWait; //How long to start until enemies start spawning
    public float spawnX; //how far to the right to instantiate enemies (This should be off the screen and then some)
    public float spawnDelayMin; //Min time between spawning enemies
    public float spawnDelayMax; //Max time between spawning enemies
    public float powerUpDelayMin; //Min time between spawning powerups
    public float powerUpDelayMax; //Max time between spawning powerups
    public float powerUpTime = 0; //this determines the power up time, when a powerup is obtained, this should be increase
    public float powerDownTime = 0; //same as above but for power downs
    public bool moving; //Safety measure for calculating score. Set to false if the player stops for any reason.
    public bool GameOver; //Disables many game features
    public bool powerFast; //If true, go fasta
    public bool powerSlow; //If tru, go slowa, slow for a sloth. A slow sloth. What has this world come to?
    public bool powerHat; //If tru, allows for temporary invincibility
    public Vector3 timeSpeeds; //(slow, reg, fast)
    public Vector3 distSpeeds; //(slow, reg, fast)

    public Text scoreText; //Reference to the score display at top left
    public Text endScoreText;
    public Text winText;
    public GameObject gameOverPanel;
    public GameObject[] life; //Holds refrences to life GUI display at top right
    public GameObject[] enemies; //Add all enemy prefabs to this array
    public GameObject[] powerUps; //Stationary objects that provide a bonus to the Sloth. Or the enemies.
	public AudioClip[] catSounds;
	public AudioClip crikey;
	public AudioClip ratSounds;

    [HideInInspector] public bool line4; //Bool of which lines are active.
    [HideInInspector] public bool line3;
    [HideInInspector] public bool line1; //the middle line (2) will ALWAYS be active. This leaves a min of 3 lines at any time, and a max of 5.
    [HideInInspector] public bool line0;

	void Start () {
		GameOver = false;
	    lives = 3; //Starting lives
        score = 0;
        distance = 0;
        time = 950; //Start at sunrise
        moving = true; //Make sure this is false if there is a delay once the player starts.
        powerFast = false;
        powerSlow = false;
        line4 = true; //Every new game starts with all 5 wires
        line3 = true; //Cause yolo that's why
        line1 = true;
        line0 = true;
        StartCoroutine(SpawnEnemies()); //Start spawn loop
		StartCoroutine(SpawnPowerUps());
		StartCoroutine (PowerUpTimer ());
	}
    
	void Update () {
		if(!GameOver){
        UpdateTime(); //Updates in-game time values that control day/night cycles
        UpdateDist(); //Updatees in-game distance and influences enemy speeds.
		}
	}

    public void Hit (Collider other) {

        switch(other.tag){
            case "Birb":
                Debug.Log("You hit a tweety birb!!"); //New Cannon: all birbs are tweety
        		Damage();
                break;
    		case "Cat":
    			playSound(catSounds [Random.Range(0,catSounds.Length-1)]);
    	    	Debug.Log("You hit a Meower!!");
                Damage();
                break;
	    case "Rat":
		Debug.Log("You hit a squeaker!!");
		playSound(ratSounds);
		break;
    	    case "Poop":
    		    Debug.Log("You got shat on m8"); //wow k
                Damage();
                break;
    		case "Shoes":
    			Debug.Log ("Gotta go fast!!");
    			powerFast = true;
    			powerUpTime += 10;
    		    break;
    		case "Web": //mrw webs are just spider poop and should be tagged as such
    			Debug.Log ("Wth is all this sticky white stuff!?");
    			powerSlow = true;
    			powerDownTime += 10;
    		    break;
            case "Hat": //Proposed change to "BadAssHat"
        		Debug.Log("Crikey! You are invincible now!!");
        		powerHat = true;
        		break;
	    }
    }

    public void Damage () //All attempts to damage Sydney should go through Damage();
    {
        if (!powerHat)
        {
            AddLives(-1); //All changes to lives should go through AddLives();
        }
    }

	IEnumerator PowerUpTimer(){
		while (!GameOver) {
			yield return new WaitForSeconds(1);
			if(powerFast){
				powerUpTime --;
				if(powerUpTime <=0){
					powerFast = false;
				}

			}

			if(powerSlow){
				powerDownTime --;
				if(powerDownTime <=0){
					powerSlow = false;
				}
			}


		}
	}
    IEnumerator SpawnPowerUps()
    {
	yield return new WaitForSeconds(startWait);
		while(!GameOver)
	{
	    GameObject powerUp; //Power up to be instantiated
	    int spawnYmax;
	    int spawnYmin;
			powerUp = powerUps[Random.Range(0, powerUps.Length)]; //Pick powerup at random
	    if (line4){ //Determine possible y values for spawning
		spawnYmax = 2;
	    } else if (line3) {
		spawnYmax = 1;
	    } else {
		spawnYmax = 0;
	    } if (line0){
		spawnYmin = -2;
	    } else if (line1){
		spawnYmin = -1;
	    } else {
		spawnYmin = 0;
	    }

	    Vector3 spawnPosition = new Vector3(spawnX, 2*Random.Range(spawnYmin,spawnYmax), 0); //Determine spawn position
	    Instantiate(powerUp, spawnPosition, Quaternion.identity); //spawn enemy
	    yield return new WaitForSeconds(Random.Range(powerUpDelayMin, powerUpDelayMax)); //Wait random time to spawn next
		}
	}
    
    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(startWait);
		while(!GameOver)
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
    }

    public void AddScore(float newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }

    public bool GetScore(int newScore)
    {
        int[] scores = new int[5];

        for (int i = 0; i<=4; i++)
        {
            scores[i] = PlayerPrefs.GetInt("score" + i);
        }

        for (int i = 0; i<=4; i++)
        {
            if (newScore > scores[i])
            {
                int ii = i;
                switch(ii){
                    case 4:
                        break;
                    case 3:
                            scores[4] = scores[3];
                        break;
                    case 2:
                        for (i = 4; i<=3; i--)
                        {
                            scores[i] = scores[i-1];
                        }
                        break;
                    case 1:
                        for (i = 4; i<=2; i--)
                        {
                            scores[i] = scores[i-1];
                        }
                        break;
                    case 0:
                        for (i = 4; i<=1; i--)
                        {
                            scores[i] = scores[i-1];
                        }
                        break;
                }
                scores[ii] = newScore;
                SetScore(scores);
                return true; //To detect if a highscore was beaten
            }
        }
        return false;
    }

    void SetScore(int[] scores)
    {
        for (int i = 0; i<=4; i++)
        {
            PlayerPrefs.SetInt("score" + i, scores[i]);
        }
    }

    public void AddLives(int newLifeValue)
    {
        lives += newLifeValue;
        UpdateLives();
    }

    void UpdateLives() //Pretty much just makes little faces at the top right go away, but also calls GameOver()
    {
        switch(lives){
            case 3:
                life[0].SetActive(true);
                life[1].SetActive(true);
                life[2].SetActive(true);
                break;
            case 2:
                life[0].SetActive(false);
                life[1].SetActive(true);
                life[2].SetActive(true);
                break;
            case 1:
                life[0].SetActive(false);
                life[1].SetActive(false);
                life[2].SetActive(true);
                break;
    		case 0:
                life[0].SetActive(false);
                life[1].SetActive(false);
                life[2].SetActive(false);        
    			Gameover();
                break;
        }
    }

    void UpdateTime() //Time needs to stay between 0 and 2400, where each unit of time in this cotext is 1/100 of and in-game hour.
    {
        if (powerFast) {
            time += Time.deltaTime * timeSpeeds[2];
        }
        else if (powerSlow) {
            time += Time.deltaTime * timeSpeeds[0];
        }
        else {
            time += Time.deltaTime * timeSpeeds[1];
        }
        time = Mathf.Repeat(time, 2400);
    }

    void UpdateDist()
    {
        if (moving) {
            if (powerFast) {
                distance += Time.deltaTime * distSpeeds[2];
                AddScore(Time.deltaTime * distSpeeds[2] * distPoints);
            }
            else if (powerSlow) {
                distance += Time.deltaTime * distSpeeds[0];
                AddScore(Time.deltaTime * distSpeeds[0] * distPoints);
            }
            else {
                distance += Time.deltaTime * distSpeeds[1];
                AddScore(Time.deltaTime * distSpeeds[1] * distPoints);
            }
        }
    }

	void Gameover()
    {
        GameOver = true;
        endScoreText.text = "" + Mathf.Floor(score);
        if (GetScore(Mathf.FloorToInt(score)))
        {
            winText.text = "You got a new highscore!";
        }
        gameOverPanel.SetActive (true);
		playSound (crikey);
	}

    public void Load(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

	void playSound(AudioClip ac)
    {
		AudioSource aa = this.GetComponent<AudioSource>();
		aa.clip = ac;
		aa.Play();
	}
}
