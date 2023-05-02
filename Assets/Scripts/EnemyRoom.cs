using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoom : Room
{
    public Door[] doors;

    public Room roomScript;
    public EnemyRoom EnemyScript;
    public AudioSwap enemyMusic;

    public int EnemiesActive()
    {
        int activeEnemies = 0;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject.activeInHierarchy)
            {
                activeEnemies++;
            }
        }
        return activeEnemies;
    }

    public void CheckEnemies()
    {
        if (EnemiesActive() == 1)
        {
            OpenDoors();
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Activate all enemies 
            for (int i = 0; i < enemies.Length; i++)
            {
                changeActivation(enemies[i], true);
            }
            CloseDoors();
            virtualCamera.SetActive(true);

        }

    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Deactivate all enemies
            for (int i = 0; i < enemies.Length; i++)
            {
                changeActivation(enemies[i], false);
            }
            virtualCamera.SetActive(false);

        }
    }

    public void CloseDoors()
    {
        for(int i = 0; i < doors.Length; i ++)
        {
            doors[i].Close();
        }
        Debug.Log("Close Doors");
    }

    public void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Open();
            roomScript.enabled = true;
            Destroy(EnemyScript);
            enemyMusic.returnToDefault();
        }
        Debug.Log("Open Doors");
    }
}
