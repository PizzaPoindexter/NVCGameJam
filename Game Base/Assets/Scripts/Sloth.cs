using UnityEngine;
using System.Collections;

public class SlothScript : MonoBehaviour
{
    public int currentWire;
    public float nextMove;
    public float climbSpeed;

    public GameController cont;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit" + other);
        //Test for type of enemy ("other"), react accordingly
    }

    void Start ()
    {
        currentWire = 2; //Starts on middle wire
        nextMove = 0; //"Cooldown" on how fast you can move up and down
    }

    void Update ()
    {
        if (Input.GetAxis("Vertical") < 0 && Time.time > nextMove) {
            switch(currentWire){
                case 4:
                    break;
                case 3:
                    if (cont.line4) {
                        //climb
                    }
                    break;
                case 2:
                    if (cont.line3) {
                        //climb
                    }
                    break;
                case 1:
                        //climb
                    break;
                case 0:
                    if (cont.line1) {
                        //climb
                    }
                    break;
            }
        }
        else if (Input.GetAxis("Vertical") < 0 && Time.time > nextMove) {
            switch(currentWire){
                case 4:
                    if (cont.line3) {
                        //climb down
                    }
                    break;
                case 3:
                        //climb down
                    break;
                case 2:
                    if (cont.line1) {
                        //climb down
                    }
                    break;
                case 1:
                    if (cont.line0) {
                        //climb down
                    }
                    break;
                case 0:
                    break;
            }
        }
    }

    void Climb(bool up)
    {
        if (up) {
            
        }
    }
}