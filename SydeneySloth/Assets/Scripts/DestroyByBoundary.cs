using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}