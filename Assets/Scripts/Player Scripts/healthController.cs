using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class healthController : MonoBehaviour
{
    //player controller script.
    public playerController myPlayerController;

    //Health Variables.
    float playerHealth = 140;
    float maxHealth = 140;

    //UI
    public Transform deathMenu;
    public Transform gameUI;
    public Image healthBar;
    public Sprite[] newHealthBar;

    string GameOver = "Gameover";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void takeDamage(float damageAmount)
    {
        //take away the damage from the players current health.
        playerHealth -= damageAmount;

        //change the fill amount for the health bar.
        if (playerHealth == 130)
        {
            healthBar.sprite = newHealthBar[1];
        }
        else if (playerHealth == 120)
        {
            healthBar.sprite = newHealthBar[2];
        }
        else if (playerHealth == 110)
        {
            healthBar.sprite = newHealthBar[3];
        }
        else if (playerHealth == 100)
        {
            healthBar.sprite = newHealthBar[4];
        }
        else if (playerHealth == 90)
        {
            healthBar.sprite = newHealthBar[5];
        }
        else if (playerHealth == 80)
        {
            healthBar.sprite = newHealthBar[6];
        }
        else if (playerHealth == 70)
        {
            healthBar.sprite = newHealthBar[7];
        }
        else if (playerHealth == 60)
        {
            healthBar.sprite = newHealthBar[8];
        }
        else if (playerHealth == 50)
        {
            healthBar.sprite = newHealthBar[9];
        }
        else if (playerHealth == 40)
        {
            healthBar.sprite = newHealthBar[10];
        }
        else if (playerHealth == 30)
        {
            healthBar.sprite = newHealthBar[11];
        }
        else if (playerHealth == 20)
        {
            healthBar.sprite = newHealthBar[12];
        }
        else if (playerHealth == 10)
        {
            healthBar.sprite = newHealthBar[13];
        }
        else if (playerHealth == 0)
        {
            healthBar.sprite = newHealthBar[14];
            SceneManager.LoadScene(GameOver);
        }
    }

    public void getHealth(float healAmount)
    {
        //add the heal amount to the players health.
        playerHealth += healAmount;

        //change the fill amount of the health bar.
        healthBar.fillAmount = playerHealth / maxHealth;
    }

    public void checkDeath()
    {
        if (playerHealth <= 0)
        {
            //display the death menu.
            deathMenu.gameObject.SetActive(true);

            //hide the ingame UI.
            gameUI.gameObject.SetActive(false);

            //stop the gameplay from running, making the user pick from the options on the death menu.
            Time.timeScale = 0;
        }
    }
}
