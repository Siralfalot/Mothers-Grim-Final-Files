using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100;
    public float bulletDamage = 50;

    public Signals roomSignal;

    public bool isDying = false;

    public void takeDamage()
    {
        //Removes health based on damage dealt
        enemyHealth -= bulletDamage;
        

        //checks to see if the total health left is less than or equal to zero
        if (enemyHealth <= 0)
        {
            FindObjectOfType<audioManager>().Play("EnemyDeath1");
            StartCoroutine(dyingEnemy());
            roomSignal.Raise();
            die();
        }
        else if (enemyHealth != 0)
        {
            FindObjectOfType<audioManager>().Play("EnemyImpact1");
        }
    }

    IEnumerator dyingEnemy()
    {
        isDying = true;
        yield return new WaitForSeconds(1.4f);
        isDying = false;
    }
    
    public void die()
    {
        //Destroy the gameobject
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Code to react to collision with bullet
            Rigidbody2D zombieRB = collision.rigidbody;
            zombieRB.AddForce(new Vector2(0, 1000));
            takeDamage();
        }

        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
