using UnityEngine;
using System.Collections;

public class destroyMe : MonoBehaviour {

	public int lifeSpan;
	// Update is called once per frame
	void Update () {
		lifeSpan--;
		if (lifeSpan <= 0) {
			Destroy (this.gameObject);
		}
	}
}
