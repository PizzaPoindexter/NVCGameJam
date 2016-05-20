using UnityEngine;
using System.Collections;

public class Dropgenerator : MonoBehaviour {


	public int dropRate = 75;
	public int frames;
	public bool dropped = false;
	public GameObject poop;
	// Update is called once per frame
	void Update () {
		if (!dropped) {
			frames++;
			if (frames >= dropRate) {
				Instantiate (poop, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
				dropped = true;
			}
		}
	}
}

				