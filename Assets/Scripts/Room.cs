using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject virtualCamera;

    public EnemyHealth[] enemies;
    public Totem[] totems;
    public RuneHealth[] runes;

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //Activate enemies and camera
            for(int i = 0; i < enemies.Length; i++)
            {
                changeActivation(enemies[i], true);
            }
            virtualCamera.SetActive(true);
        }
    }

    public virtual void OnTriggerExit2D (Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            //Deactivate enemies and camera
            for(int i = 0; i < enemies.Length; i++)
            {
                changeActivation(enemies[i], false);
            }
            virtualCamera.SetActive(false);
        }
    }

    public void changeActivation(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);
    }

}
