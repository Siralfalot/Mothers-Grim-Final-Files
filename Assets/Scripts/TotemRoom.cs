using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemRoom : Room
{
    public Door[] doors;

    public Room roomScript;
    public TotemRoom TotemScript;

    public int TotemsActive()
    {
        int activeTotems = 0;
        for (int i = 0; i < totems.Length; i++)
        {
            if (totems[i].gameObject.activeInHierarchy)
            {
                activeTotems++;
            }
        }
        return activeTotems;
    }

    public void checkTotems()
    {
        if (TotemsActive() == 1)
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
        Destroy(TotemScript);
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            //Activate totems and camera
            for (int i = 0; i < totems.Length; i++)
            {
                changeActivation(totems[i], true);
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
            for (int i = 0; i < totems.Length; i++)
            {
                changeActivation(totems[i], false);
            }
            virtualCamera.SetActive(false);
        }
    }
}
