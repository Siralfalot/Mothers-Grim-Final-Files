using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    bool Paused = false;
    public bool Pausing = false;
    public bool Unpausing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Paused == false && Pausing == true)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 00);
            Time.timeScale = 0;
            AudioListener.pause = true;

            Paused = true;

            Pausing = false;
        }

        if (Paused == true && Unpausing == true)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(2500, 00);
            Time.timeScale = 1;
            AudioListener.pause = false;


            Paused = false;

            Unpausing = false;
        }

    }
}
