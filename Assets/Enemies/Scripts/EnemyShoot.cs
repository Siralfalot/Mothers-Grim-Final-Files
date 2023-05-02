using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float cooldown = 0;
    float lastShot;

    public bool isShooting;

    void Start()
    { 
        StartCoroutine(WaitTime());
    }

    // Update is called once per frame
    void Update()
    {
        if(isShooting == true)
        {
            return;
        }
            Shoot();
    }

    public void Shoot()
    {
        if(Time.time - lastShot<cooldown)
        {
            return;
        }
        lastShot = Time.time;
        FindObjectOfType<audioManager>().Play("EnemyRangedAttack");
        StartCoroutine(WaitTime());

        

        
    }

    IEnumerator WaitTime()
    {
        isShooting = true;
        yield return new WaitForSeconds(1.5f);


        GameObject bullet1 = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 0));

        Rigidbody2D bulletRb1 = bullet1.GetComponent<Rigidbody2D>();

        bulletRb1.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }
}
