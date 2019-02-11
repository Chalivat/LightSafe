using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    Animator anim;
    bool isOpen;
    private void Start()
    {
        isOpen = false;
        anim = GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("PlayerDetecter") && Input.GetKeyDown(KeyCode.Space))
        {
            if (isOpen)
            {
                isOpen = false;
                anim.Play("DoorClosing");
            }
            else
            {
                isOpen = true;
                anim.Play("DoorOpening");
            }
        }
    }
}
