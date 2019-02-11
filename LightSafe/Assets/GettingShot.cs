using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingShot : MonoBehaviour
{
    int life = 2;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (life <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Shot()
    {
        life--;
    }
}
