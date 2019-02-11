using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGenerator : MonoBehaviour
{
    public GameObject point;
    public float length;
    void Start()
    {
        GeneratePoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneratePoint()
    {
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                Instantiate(point, new Vector3(i * 4 , 0, j *4), Quaternion.identity);
            }
        }
    }
}
