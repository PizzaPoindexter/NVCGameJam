using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float xspeed; // basically meters per second, but adjust through playtesting
	public float yspeed;
    void Update() {
		transform.Translate(Time.deltaTime * xspeed, Time.deltaTime * yspeed, 0); //Converts speed to m/s, and applies it to the objects transform
    }
}
