using UnityEngine;
using System.Collections;

public class LightChanger : MonoBehaviour {

    public bool doColor;
    public Color color1; //Color.blue Day
    public Color color2; //Color.red Sunset
    public Color color3; //Color.gray Night
    public bool doIntensity;
    public float intensity1;
    public float intensity2;
    public float intensity3;

    public GameController cont;

    private Light lt;
    private int dummy;

    void Start () {
        lt = GetComponent<Light>();
    }

    void Update () {
        if (400 <= cont.time && cont.time < 600) { //Moonset
            if (doColor){ lt.color = Color.Lerp(color3, color2, Mathf.Repeat(cont.time/200, 1));}
            if (doIntensity){ lt.intensity = Mathf.Lerp(intensity3, intensity2, Mathf.Repeat(cont.time/200, 1));}
            Debug.Log("Moonset");
        }
        else if (600 <= cont.time && cont.time < 800) { //Sunrise
            if (doColor){ lt.color = Color.Lerp(color2, color1, Mathf.Repeat(cont.time/200, 1));}
            if (doIntensity){ lt.intensity = Mathf.Lerp(intensity2, intensity1, Mathf.Repeat(cont.time/200, 1));}
            Debug.Log("Sunrise");
        }
        else if (1400 <= cont.time && cont.time < 1600) { //Sunset
            if (doColor){ lt.color = Color.Lerp(color1, color2, Mathf.Repeat(cont.time/200, 1));}
            if (doIntensity){ lt.intensity = Mathf.Lerp(intensity1, intensity2, Mathf.Repeat(cont.time/200, 1));}
            Debug.Log("Sunset");
        }
        else if (1600 <= cont.time && cont.time < 1800) { //Moonrise
            if (doColor){ lt.color = Color.Lerp(color2, color3, Mathf.Repeat(cont.time/200, 1));}
            if (doIntensity){ lt.intensity = Mathf.Lerp(intensity2, intensity3, Mathf.Repeat(cont.time/200, 1)) ;}
            Debug.Log("Moonrise");
    }
    }
}
