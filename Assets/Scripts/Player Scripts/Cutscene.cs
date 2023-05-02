using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    public bool inCutscene = false;

    public GameObject VideoPlayer;
    public GameObject RawImage;
    public GameObject PauseButton;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cutscene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator cutscene()
    {
        inCutscene = true;
        yield return new WaitForSeconds(112);
        inCutscene = false;
        PauseButton.SetActive(true);
        VideoPlayer.SetActive(false);
        RawImage.SetActive(false);
    }
}
