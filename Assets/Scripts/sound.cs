using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

public class sound
{
    //name
    public string name;

    //source audio clip
    public AudioClip clip;

    //if it should be looped
    public bool loop;

    //slider to select volume.
    [Range(0f, 1f)]
    public float volume;

    //slider to select pitch.
    [Range(.1f, 3)]
    public float pitch;

    [HideInInspector] // hide the audiosource source in the unity inspector.
    public AudioSource source;
}
