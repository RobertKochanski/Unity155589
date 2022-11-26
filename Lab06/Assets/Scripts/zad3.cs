using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    public List<Transform> points;
    [SerializeField]
    private float speed = 3;
    private int current = 0;
    private int next = 1;
    private bool isRunning;

    void Start()
    {
    }

    void Update()
    {
        if (isRunning)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speed * Time.deltaTime);
            if (transform.position == points[current].position)
            {
                if (current >= points.Count - 1)
                {
                    next = -1;
                }
                else if (current <= 0)
                {
                    next = 1;
                }
                current += next;
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
            other.gameObject.transform.parent = null;
        }
    }
}
