using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeFailScript : MonoBehaviour
{
    public Vector3 PlayerMove;

    public healthController playerhealthcontroller;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = PlayerMove;

            playerhealthcontroller.takeDamage(10);
        }
    }
}
