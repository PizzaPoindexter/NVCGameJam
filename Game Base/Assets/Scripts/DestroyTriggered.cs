using UnityEngine;
using System.Collections;

public class DestroyTriggered : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		Destroy(this.gameObject);
	}
}
