using UnityEngine;
using System.Collections;

public class MapGenerator: MonoBehaviour {
	
	void generate ()
	{
		int wires = Random.Range(3,6);
		
		if(wires == 5) {
			line4 = true;
			line3 = true;
            line1 = true;
            line0 = true;
        }   

        if (wires==4) {

            switch(Random.Range(0,2)){
            case 1: //Cuts off top wire
                line4 = false;
                line3 = true;
                line1 = true;
                line0 = true;
                break;
            case 0: //Cuts off bottom wire
                line4 = true;
                line3 = true;
                line1 = true;
                line0 = false;
                break;
            }
        }

            if (wires==3) {

            switch(Random.Range(0,3)){
            case 2: //Cuts off top 2 wires
                line4 = false;
                line3 = false;
                line1 = true;
                line0 = true;
                break;
            case 1: //Allows for middle 3 to be active, cutting off both top and bottom
                line4 = false;
                line3 = true;
                line1 = true;
                line0 = false;
                break;
            case 0: //Cuts off bottom two wires
                line4 = true;
                line3 = true;
                line1 = false;
                line0 = false;
                break;
            }
        }

        //Proceed to generate wires for these lines.
        //Lines should be 2 meters (unity units are meters) apart vertically. Use the prefabs.
        //Include random webs and frays at random intervals.
        //Prevent stacking, so that you can't get a solid collumn of frays, making it impossible to corss safely.
    }
}
