using UnityEngine;
using System.Collections;

/*******************************************/
/* Script to detect collision and generate */
/* maps upon doing so.                     */
/* author: Travis S. Tatsch                */
/*******************************************/

public class MapCollision : MonoBehaviour
{
	void OnCollision(Collider other)
	{
		MapGenerator generator = new MapGenerator();
		generator.generate();
		Debug.Log("Map generated");
	}
}
