using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Zadanie5 : MonoBehaviour
{
    public GameObject myPrefab;

    void Start()
    {
        List<Vector3> posList = new List<Vector3>();
        Vector3 pos;
        for (int i = 0; i < 10; i++)
        {
            do
            {
                pos = new Vector3(Random.Range(-4, 4), Random.Range(0.0f, 0.5f), Random.Range(-4, 4));
            }
            while (posList.Contains(pos));

            posList.Add(pos);
        }

        foreach (var item in posList)
        {
            Instantiate(myPrefab, item, Quaternion.identity);
        }
    }
    void Update()
    {
        
    }
}
