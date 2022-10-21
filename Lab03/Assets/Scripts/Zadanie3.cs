using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie3 : MonoBehaviour
{
    public float speed = 10.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.x < 10 && transform.rotation.eulerAngles.y == 0)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 10 && transform.rotation.eulerAngles.y == 0)
        {
            transform.Rotate(0, 90, 0);
        }

        if (transform.position.z > -10 && transform.rotation.eulerAngles.y == 90)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
        }
        else if(transform.position.z <= -10 && transform.rotation.eulerAngles.y == 90)
        {
            transform.Rotate(0, 90, 0);
        }

        if (transform.position.x > -10 && transform.rotation.eulerAngles.y == 180)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else if(transform.position.x <= -10 && transform.rotation.eulerAngles.y == 180)
        {
            transform.Rotate(0, 90, 0);
        }

        if (transform.position.z < 10 && transform.rotation.eulerAngles.y == 270)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
        }
        else if(transform.position.z >= 10 && transform.rotation.eulerAngles.y == 270)
        {
            transform.Rotate(0, 90, 0);
        }
    }
}
