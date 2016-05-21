using UnityEngine;
using System.Collections;

public class BackgroundColor : MonoBehaviour {

    public Color color1; //Color.blue Day
    public Color color2; //Color.red Sunset
    public Color color3; //Color.gray Night

    public GameController cont;

    private Camera cam;

    void Start () {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }
	
	void Update () {
        if (600 <= cont.time && cont.time < 800) { //Moonset
    	    cam.backgroundColor = Color.Lerp(color3, color2, Mathf.Repeat(cont.time/200, 1));
        }
        else if (800 <= cont.time && cont.time < 1000) { //Sunrise
            cam.backgroundColor = Color.Lerp(color2, color1, Mathf.Repeat(cont.time/200, 1));
        }
        else if (1400 <= cont.time && cont.time < 1600) { //Sunset
            cam.backgroundColor = Color.Lerp(color1, color2, Mathf.Repeat(cont.time/200, 1));
        }
        else if (1600 <= cont.time && cont.time < 1800) { //Moonrise
            cam.backgroundColor = Color.Lerp(color2, color3, Mathf.Repeat(cont.time/200, 1));
    }
	}
}
