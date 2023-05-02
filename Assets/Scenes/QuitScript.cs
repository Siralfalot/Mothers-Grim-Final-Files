using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuitScript : MonoBehaviour
{

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
                Application.Quit();
        }

    }
}
