using UnityEngine;
using System.Collections;

public class Sloth : MonoBehaviour
{
	public class Stats
	{
		public float speed;      
        public Stats myStats = new Stats(1.0f);

		public Stats(float spd)
		{
			speed = spd;
		}      
    	
    	void Update()
    	{
    		Movement();
    	}

    	void Movement()
    	{
    		//float 
        }
    }
}