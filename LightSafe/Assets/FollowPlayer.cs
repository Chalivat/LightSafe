using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject player;
    public float offset;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        float x = player.transform.position.x;
        float z = player.transform.position.z;

        transform.position = new Vector3(x, transform.position.y, z + offset);
        
    }
}
