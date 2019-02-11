using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrackPlayer : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    bool aware;
    bool see;
    public float aggroDistance;
    public GameObject[] ronde;
    int i;
    bool asArrived = true;
    LayerMask layerMask;
    LayerMask defaultMask;
    public float attackDistance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        layerMask = LayerMask.GetMask("Player");
        defaultMask = LayerMask.GetMask("Default");
        i = 0;
    }
    
    void Update()
    {
        //Debug.Log(see);
        //Debug.Log(Vector3.Distance(player.transform.position, transform.position));
        CheckPlayer();
        if (see)
        {
            Poursuite();
        }
        else Ronde();
    }

    

    void Ronde()
    {
        if (asArrived)
        {
            agent.SetDestination(ronde[i].transform.position);
            asArrived = false;
        }

        //Debug.Log(Vector3.Distance(transform.position, ronde[i].transform.position));

        if (Vector3.Distance(transform.position, ronde[i].transform.position) <=2f)
        {
            if (i >= (ronde.Length -1))
            {
                i = 0;
            }
            else i++;
            asArrived = true;
        }
    }

    void CheckPlayer()
    {
        RaycastHit hit;
        Vector3 direction = player.transform.position - transform.position;
        Debug.DrawLine(transform.position, player.transform.position, Color.red);
        
        if ((Vector3.Distance(player.transform.position, transform.position) <= aggroDistance))
        {
            see = true;
            if (Physics.Raycast(transform.position, direction, out hit, aggroDistance, defaultMask))
            {
                Debug.DrawLine(transform.position, direction, Color.blue);
                see = false;
            }
        }
        else
        {
            see = false;
            asArrived = true;
        }
        
    }

    void Poursuite()
    {
        if (!(Vector3.Distance(player.transform.position, transform.position) <= attackDistance))
        {
            agent.SetDestination(player.transform.position);
        }
        else agent.SetDestination(transform.position);
    }
}
