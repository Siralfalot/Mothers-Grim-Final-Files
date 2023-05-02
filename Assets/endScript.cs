using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScript : MonoBehaviour
{
    public GameObject FinalAnim;
    public Vector2 animSpawn;
    public Transform spawnLocation;
    public GameObject oldCamera;
    public GameObject newCamera;
    public Cinemachine.CinemachineBrain cameraSettings;
    public GameObject characterLight;
    public GameObject openDoor;

    public shootingController myShootingController;
    public SpriteRenderer playerRender;

    private void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRender.enabled = false;
            myShootingController.canMove = false;
            characterLight.SetActive(false);
            openDoor.SetActive(true);
            FinalAnim.SetActive(true);
            FindObjectOfType<audioManager>().Play("DoorSound");
            FindObjectOfType<audioManager>().Play("EndSound");
            StartCoroutine(DoorClose());

            oldCamera.SetActive(false);
            cameraSettings.m_DefaultBlend.m_Time = 7;
            newCamera.SetActive(true);
        }
    }

    IEnumerator DoorClose()
    {
        yield return new WaitForSeconds(3);
        openDoor.SetActive(false);
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("Load");
    }
}
