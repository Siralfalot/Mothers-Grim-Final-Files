using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneHealth : MonoBehaviour
{
    public float runeHealth = 50;
    public float bulletDamage = 50;

    public Signals roomSignal;

    public void takeDamage()
    {
        //Removes health based on damage dealt
        runeHealth -= bulletDamage;


        //checks to see if the total health left is less than or equal to zero
        if (runeHealth <= 0)
        {
            FindObjectOfType<audioManager>().Play("RuneBreak");
            FindObjectOfType<audioManager>().Play("RuneBreak2");
            roomSignal.Raise();
            die();
        }
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
