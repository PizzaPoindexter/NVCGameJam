using UnityEngine;
using System.Collections;

public class BGRotator : MonoBehaviour {

    public float scrollSpeed;

    public GameController cont;

    void Update () {
        transform.eulerAngles = new Vector3(0, 0, -(cont.time - 1200) * scrollSpeed);
    }
}