using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

    public Text[] scoreText;

    void Start () 
    {
        for (int i = 0; i<=4; i++)
        {
            scoreText[i].text = "" + PlayerPrefs.GetInt("score" + i);
        }
    }

    public void ResetScores()
    {
        for (int i = 0; i<=4; i++)
        {
            PlayerPrefs.SetInt("score" + i, 0);
        }
    }
}
