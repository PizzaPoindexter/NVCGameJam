using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed; // basically meters per second, but adjust through playtesting

    void Update() {
        transform.Translate(Time.deltaTime * speed, 0, 0); //Converts speed to m/s, and applies it to the objects transform
    }
}
