using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneRoom : Room
{
    public Door[] doors;

    public Room roomScript;
    public RuneRoom RuneScript;

    public int RunesActive()
    {
        int activeRunes = 0;
        for (int i = 0; i < runes.Length; i++)
        {
            if (runes[i].gameObject.activeInHierarchy)
            {
                activeRunes++;
            }
        }
        return activeRunes;
    }

    public void checkRunes()
    {
        if (RunesActive() == 1)
        {
            OpenDoors();
        }
    }

    public void CloseDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Close();
        }
    }

    public void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Open();
        }
        FindObjectOfType<audioManager>().Play("TotemActivation");
        roomScript.enabled = true;
        Destroy(RuneScript);
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Activate enemies and camera
            for (int i = 0; i < runes.Length; i++)
            {
                changeActivation(runes[i], true);
            }
            virtualCamera.SetActive(true);
            CloseDoors();
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Deactivate enemies and camera
            for (int i = 0; i < runes.Length; i++)
            {
                changeActivation(runes[i], false);
            }
            virtualCamera.SetActive(false);
        }
    }
}
