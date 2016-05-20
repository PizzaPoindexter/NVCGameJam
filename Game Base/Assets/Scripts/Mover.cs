using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed; //Basically meters per second, but adjust through playtesting

    private float slothAdjust;
    private GameController cont; //Reference to GameController Script, to find current speed

    void Start() {
        cont = GameObject.FindWithTag("GameController").GetComponent<GameController>(); //Finds the GameContorller script onthe GameController object
    }

    void Update() {
        if (cont.powerFast) { //Adjust mob speed by sloth speeds, since the sloth doesn't actually move, the mobs would have to go faster when the sloth is going faster
            slothAdjust = cont.distSpeeds[2]-cont.distSpeeds[1];
        }
        if (cont.powerFast) { //Slows down mobs when sloth is going slower
            slothAdjust = cont.distSpeeds[0]-cont.distSpeeds[1];
        }
        transform.Translate(Time.deltaTime * speed + slothAdjust, 0, 0); //Converts speed to m/s, and applies it to the objects transform
    }
}