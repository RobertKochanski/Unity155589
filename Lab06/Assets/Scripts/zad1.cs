using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad1 : MonoBehaviour
{
    private Vector3 start;
    public Transform point;
    private float speed = 3;
    private bool turn = false;
    private bool isRunning;

    void Start()
    {
        start = transform.position;
    }

    void Update()
    {
        if (isRunning)
        {
            if (!turn)
            {
                transform.position = Vector3.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
                if (transform.position == point.position) {
                    turn = true;
                }
            }
            if (turn)
            {
                transform.position = Vector3.MoveTowards(transform.position, start, speed * Time.deltaTime);
                if (transform.position == start) { 
                    turn = false; 
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            isRunning = true;
            other.gameObject.transform.parent = transform;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRunning = false;
            other.gameObject.transform.parent = null;
        }
    }
}
