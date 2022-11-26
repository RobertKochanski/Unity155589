using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad5 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Dupa");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Walniêto w przeszkodê");
        }
    }
}
