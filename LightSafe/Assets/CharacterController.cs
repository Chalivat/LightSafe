using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float speed;
    public float sprintSpeed;
    public float walkSpeed;
    bool isSprinting = false;
    private Rigidbody rb;
    Camera cam;
    int floorMask;
    public float rotationSpeed;
    void Start()
    {
        speed = walkSpeed;
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        floorMask = LayerMask.GetMask("Ground");
    }
    
    void FixedUpdate()
    {
        Viser();
        Move();
        Sprint();
    }

    void Viser()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(camRay, out hit, 100f, floorMask ))
        {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRot = Quaternion.LookRotation(playerToMouse);
            
            rb.MoveRotation(Quaternion.Lerp(transform.rotation,newRot,rotationSpeed * Time.deltaTime));
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            rb.AddForce(Vector3.back * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.forward* speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode.VelocityChange);
        }

    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
        
    }
}
