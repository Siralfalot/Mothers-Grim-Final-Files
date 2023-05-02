using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy
}

public class Door : Interactable
{
    [Header("Door variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public playerInventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    public GameObject[] doorOpenAnim;

    public void update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(playerInRange)
            {

            }
        }
    }

    public void Open()
    {
        doorSprite.enabled = false;
        open = true;
        physicsCollider.enabled = false;

        StartCoroutine(doorOpen());

        
    }

    public void Close()
    {
        doorSprite.enabled = true;
        open = false;
        physicsCollider.enabled = true;
    }

    public void changeActivation(GameObject gameObject, bool activation)
    {
        gameObject.SetActive(activation);
    }

    IEnumerator doorOpen()
    {
        for(int i = 0; i < doorOpenAnim.Length; i++)
        {
            FindObjectOfType<audioManager>().Play("ScrapeWood");
            changeActivation(doorOpenAnim[i], true);
        }

        yield return new WaitForSeconds(0.8f);

        for(int i = 0; i < doorOpenAnim.Length; i++)
        {
            changeActivation(doorOpenAnim[i], false);
        }
    }
}
