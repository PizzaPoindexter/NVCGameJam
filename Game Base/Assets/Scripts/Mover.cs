using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	private GameObject gController;
	private GameController contr;
	public float xspeed; // basically meters per second, but adjust through playtesting
	public float yspeed;
	void Start(){
		gController = GameObject.FindGameObjectWithTag ("GameController");
		contr = gController.GetComponent<GameController>();
	}
    void Update() {
		if (contr.powerFast) {
			transform.Translate (Time.deltaTime * xspeed * 2, Time.deltaTime * yspeed, 0); //Converts speed to m/s, and applies it to the objects transform

		} else if (contr.powerSlow) {
			transform.Translate(Time.deltaTime * xspeed/2, Time.deltaTime * yspeed, 0); //Converts speed to m/s, and applies it to the objects transform

		}else{
		transform.Translate(Time.deltaTime * xspeed, Time.deltaTime * yspeed, 0); //Converts speed to m/s, and applies it to the objects transform
		}
    }
}
