using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class zad2 : MonoBehaviour
{
    private Vector3 start;
    private Vector3 startCollider;
    private Vector3 point;
    private float speed = 3;
    private bool turn = false;
    private bool isRunning;

    void Start()
    {
        start = transform.position;
        startCollider = transform.GetChild(0).position;
        point = new Vector3(start.x, start.y, start.z - 10);
    }

    void Update()
    {
        transform.GetChild(0).position = startCollider;
        if (turn)
        {
            transform.position = Vector3.MoveTowards(transform.position, point, speed * Time.deltaTime);
        }
        if (!turn)
        {
            transform.position = Vector3.MoveTowards(transform.position, start, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            turn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            turn = false;
        }
    }
}
