using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie2 : MonoBehaviour
{
    public float speed = 10.0f;
    public int direction = 0;

    void Start()
    {

    }

    void Update()
    {
        if (transform.position.x >= 10)
        {
            direction = -1;
        }
        else if (transform.position.x <= 0)
        {
            direction = 1;
        }
        transform.position = new Vector3(transform.position.x + (speed * direction) * Time.deltaTime, transform.position.y, 0);
    }
}
