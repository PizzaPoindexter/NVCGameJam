using UnityEngine;
using System.Collections;

public class BGChanger : MonoBehaviour {

    public Vector2 times;
    public Color color1;
    public Color color2;

    public GameController cont;
    public SpriteRenderer[] lights;

    void Update () {
        if (times[0] < cont.time && cont.time < times[0] + 200) { //Turn On
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].color = Color.Lerp(color1, color2, Mathf.Repeat(cont.time/200, 1));
            }
        }
        else if (times[1] < cont.time && cont.time < times[1] + 200) { //Turn Off
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].color = Color.Lerp(color2, color1, Mathf.Repeat(cont.time/200, 1));
            }
        }
    }
}
