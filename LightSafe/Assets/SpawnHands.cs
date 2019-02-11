using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHands : MonoBehaviour
{
    public GameObject[] positions; // ou spawn la main
    private GameObject[] hands; // On garde la trace de chaque main pour les gerer en fonction du level d'aggro
    public GameObject hand; // Le modèle de base a spawn
    private float aggroLevel; // le level d'aggro
    int index; // Quelle main spawn
    float time; // le timer
    void Start()
    {
        aggroLevel = 0;
    }
    
    void Update()
    {
        
    }

    void DisplayHands()
    {
        time += Time.deltaTime;
        if (time >= 3)
        {
            time = 0;
            hands[index] = Instantiate(hand, positions[Random.Range(0,5)].transform.position, Quaternion.identity);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
