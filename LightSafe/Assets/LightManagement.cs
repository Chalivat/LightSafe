using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManagement : MonoBehaviour
{
    public float lampHealth;
    public float depleteSpeed;
    public Light lamp;
    public float maxIntensity;

    void Start()
    {
        maxIntensity = lamp.intensity;
    }
    
    void Update()
    {
        DepleteLamp();
    }

    void DepleteLamp()
    {
        lampHealth -= Time.deltaTime * depleteSpeed;
        lamp.intensity = (lampHealth * maxIntensity) / 100f;
        
    }
}
