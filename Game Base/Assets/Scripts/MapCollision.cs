using UnityEngine;
using System.Collections;

public class MapCollision : MonoBehaviour
{
    public MapGenerator mapGen;

	void OnCollision(Collider other)
	{
        if (other.tag == "Player")
        {
    		mapGen.RandomMap();
        }
	}
}