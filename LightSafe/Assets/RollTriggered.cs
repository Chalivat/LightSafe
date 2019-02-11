using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTriggered : MonoBehaviour
{
    Firing firing;
    
    void Start()
    {
        firing = GameObject.FindGameObjectWithTag("Player").GetComponent<Firing>();
    }
    
    public void Shot()
    {
        firing.didShot();
    }
}
