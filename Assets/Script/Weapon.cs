using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float fireRate = 0;
    public float weaponDmg = 10;
    public LayerMask notToHit;
    public float timeToFire;
    public Transform firePoint;

    void Awake()
    {
        firePoint = transform.Find("firePoint");
        if (firePoint == null)
        {

        }
          
    }

    // Update is called once per frame
    void Update()
    {
        if(fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1")){
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire){
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
           
        }
    }


    void Shoot()
    {
        Debug.Log("Test");
        
    }
}
