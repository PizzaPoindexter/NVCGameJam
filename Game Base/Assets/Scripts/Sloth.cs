using UnityEngine;
using System.Collections;

public class SlothScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit" + other);
        //Test for type of enemy, react accordingly
    }
}