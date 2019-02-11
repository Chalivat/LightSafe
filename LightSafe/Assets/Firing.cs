using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public GameObject Pistol;
    public GameObject lamp;
    public float fireTime;
    bool isFiring;
    float time;
    LayerMask ennemyMask;
    public bool asPistol;
    int ammo = 5;
    public GameObject[] bullets;
    public AnimationClip[] anims;
    public Animator animator;
    bool canShoot;
    void Start()
    {
        Pistol.SetActive(false);
        lamp.SetActive(false);
        ennemyMask = LayerMask.GetMask("Ennemy");
    }
    
    void Update()
    {
        //AsPistol();
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            canShoot = false;
            AnimateBarilet();
            lamp.SetActive(true);
            isFiring = true;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100f, ennemyMask))
            {
                Debug.Log(hit.transform.gameObject.name);
                hit.transform.gameObject.GetComponent<GettingShot>().Shot();
            }
        }
        if (isFiring)
        {
            time += Time.deltaTime;
            if (time >= fireTime)
            {
                time = 0;
                isFiring = false;
                lamp.SetActive(false);
            }
        }

        
    }

    void AsPistol()
    {
        if (asPistol)
        {
            Pistol.SetActive(true);
        }
        else Pistol.SetActive(false);
    }

    void AnimateBarilet()
    {
        bullets[ammo -1].SetActive(false);
        animator.Play(anims[ammo - 1].name);
        ammo--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pistol"))
        {
            asPistol = true;
            Pistol.SetActive(true);
            Destroy(other.gameObject);
            canShoot = true;
        }
    }

    public void didShot()
    {
        canShoot = true;
    }
}
