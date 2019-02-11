using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCatch : MonoBehaviour
{
    public GameObject[] Ennemis;
    public GameObject[] spawnPos;
    public bool triggered;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            for (int i = 0; i < Ennemis.Length; i++)
            {
                Instantiate(Ennemis[i ], spawnPos[i].transform.position, Quaternion.identity);
            }
        }
    }

}
