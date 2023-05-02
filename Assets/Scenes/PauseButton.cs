using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool click = false;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        click = true;
    }

    void Update()
    {
        if (click == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject.Find("Background").GetComponent<PauseScript>().Pausing = true;
            }
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        click = false;
    }
}
