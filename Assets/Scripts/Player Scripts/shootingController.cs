using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingController : MonoBehaviour
{
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float coolDown;
    float lastShot;

    public bool canMove = true;

    playerController myPlayerController;

    public Cutscene myCutsceneScript;

    void Start() 
    {
        myPlayerController = GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot(); 

        }
    }

    public void Shoot()
    {
        if(Time.time - lastShot<coolDown)
        {
            return;
        }
        else if(myCutsceneScript.inCutscene == true)
        {
            return;
        }
        lastShot = Time.time;
        FindObjectOfType<audioManager>().Play("Shoot");
        StartCoroutine(attackPause());
        

    }

    IEnumerator attackPause()
    {
        canMove = false;
        yield return new WaitForSeconds(0.5f);

        
        GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        //GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        //GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);

        Rigidbody2D bulletRb1 = bullet1.GetComponent<Rigidbody2D>();
        //Rigidbody2D bulletRb2 = bullet2.GetComponent<Rigidbody2D>();
        //Rigidbody2D bulletRb3 = bullet3.GetComponent<Rigidbody2D>();

        bulletRb1.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
        //bulletRb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
        //bulletRb3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);
        
        yield return new WaitForSeconds(0.5f);
        canMove = true;
    }
}
