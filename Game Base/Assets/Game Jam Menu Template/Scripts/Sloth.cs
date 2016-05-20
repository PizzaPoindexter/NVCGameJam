using UnityEngine;
using System.Collections;

public class Sloth : MonoBehavior
{
	public class Stats
	{
		public int lives;
		public float speed;

		public Stats(int liv, int spd)
		{
			lives = liv;
			speed = spd;
		}

	public Stats myStats = new Stats(5, 1.0);
	
	void Update()
	{
		Movement();
	}

	void Movement()
	{
		float 
}
