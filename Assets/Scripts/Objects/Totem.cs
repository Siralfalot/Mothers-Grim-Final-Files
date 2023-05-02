using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Totem : MonoBehaviour
{
    public GameObject litTotem;
    public GameObject unlitTotem;
    public BoxCollider2D physicsCollider;
    public bool lit;
    public bool playerInRange;

    public Signals roomSignal;

    public void update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space) && playerInRange == true)
        {
            if (unlitTotem.activeInHierarchy == false)
            {
                LitTorch();
            }
        }*/
    }

    public void LitTorch()
    {
        litTotem.SetActive(true);
        if (roomSignal != null)
            
            roomSignal.Raise();
        
        unlitTotem.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInRange = true;
            LitTorch();
            FindObjectOfType<audioManager>().Play("TotemLightUp");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInRange = false;
        }
    }
}
