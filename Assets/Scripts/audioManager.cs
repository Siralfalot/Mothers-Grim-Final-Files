using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public sound[] sounds;

    

    public static audioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        //Checks if there is already an instance of the gameobject this script is applied to
        if (instance == null) //if there is not another
        {
            //it will make the gameobject the instance
            instance = this;
        }
        else //if there is another
        {
            //it will destroy itself.
            Destroy(gameObject);
            return;
        }
        
        //loads itself into any scene the user loads since its first time being loaded.
        DontDestroyOnLoad(gameObject);

        //applies all the following lines of code to each sound clip in the sound array.
        foreach (sound s in sounds)
        {
            //allows the user to make a new sound and name it.
            s.source = gameObject.AddComponent<AudioSource>();
            //upload an audio clip 
            s.source.clip = s.clip;

            //adjust the volume of the audio clip.
            s.source.volume = s.volume;
            //adjust the pitch
            s.source.pitch = s.pitch;
            //select whether or not the clip will loop.
            s.source.loop = s.loop;
        }
    }

    public void Start()
    {
        
    }

    //function to play an audio clip from other scripts
    public void Play(string name)
    {
        //search the array to search for the clip (sound) by going through each sound in the array and comparing its name (sound.name) and playing it if its the right sound (sound.name == name)
        sound s = Array.Find(sounds, sound => sound.name == name);
        //playing the sound
        s.source.Play();
    }
}