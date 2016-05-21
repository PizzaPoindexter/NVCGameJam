using UnityEngine;
using System.Collections;

public class MapGenerator: MonoBehaviour {

    public Vector3 spawnPosition;

    public GameController cont;
    public GameObject[] maps;

	public void RandomMap ()
	{
		int wires = Random.Range(3,6);
        int map = 0;
        Debug.Log("wires: " + wires);

		if (wires == 5)
        {
			cont.line4 = true;
            cont.line3 = true;
            cont.line1 = true;
            cont.line0 = true;
            map = 0;
            Debug.Log("PreMap: " + map);
        }   
        else if (wires==4)
        {
            switch(Random.Range(0,2))
            {
                case 1: //Cuts off top wire
                    cont.line4 = false;
                    cont.line3 = true;
                    cont. line1 = true;
                    cont.line0 = true;
                    map = 2;
                    break;
                case 0: //Cuts off bottom wire
                    cont.line4 = true;
                    cont.line3 = true;
                    cont.line1 = true;
                    cont.line0 = false;
                    map = 1;
                    break;
            }
        }
        else
        {
            switch(Random.Range(0,3))
            {
                case 2: //Cuts off top 2 wires
                    cont.line4 = false;
                    cont.line3 = false;
                    cont.line1 = true;
                    cont.line0 = true;
                    map = 5;
                    break;
                case 1: //Allows for middle 3 to be active, cutting off both top and bottom
                    cont.line4 = false;
                    cont.line3 = true;
                    cont.line1 = true;
                    cont.line0 = false;
                    map = 4;
                    break;
                case 0: //Cuts off bottom two wires
                    cont.line4 = true;
                    cont.line3 = true;
                    cont.line1 = false;
                    cont.line0 = false;
                    map = 3;
                    break;
            }
        }
        Debug.Log("map: " + map);
        //SetMap(map);
    }

    public void SetMap (int map)
    {
        Instantiate(maps[map], spawnPosition, Quaternion.identity); //spawn map
    }
}