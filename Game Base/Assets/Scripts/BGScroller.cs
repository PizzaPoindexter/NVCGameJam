using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed;
    public float tileSizeX; //74.25

    public GameController cont;

    private Vector3 startPosition;

    void Start () {
        startPosition = transform.position;
    }

    void Update () {
        float newPosition = Mathf.Repeat(cont.distance * scrollSpeed, tileSizeX);
        transform.position = new Vector3(-newPosition, 0, 0);
    }
}