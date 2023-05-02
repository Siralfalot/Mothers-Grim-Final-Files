using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class VolumeSlider : MonoBehaviour
{
    public float test;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = GameObject.Find("VolumeObject").GetComponent<VolumeValue>().Volume;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("VolumeObject").GetComponent<VolumeValue>().Volume = slider.value;
        test = slider.value;
    }
}
