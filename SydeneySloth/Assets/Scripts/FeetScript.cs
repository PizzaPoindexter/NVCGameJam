using UnityEngine;
using System.Collections;

public class FeetScript : MonoBehaviour {

	private SlothScript sScript;

	// Use this for initialization
	void Start () {
		sScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<SlothScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Cat") {
			sScript.Climb (false);
		}
		Debug.Log ("AKSDJLASKJD");
	}
}
