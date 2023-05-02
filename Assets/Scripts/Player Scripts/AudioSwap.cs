using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwap : MonoBehaviour
{
    public AudioClip newTrack;
    public AudioSwap deleteCode;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MusicManager.instance.SwapTrack(newTrack);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MusicManager.instance.ReturnToDefault();
        }
    }

    public void returnToDefault()
    {
        MusicManager.instance.ReturnToDefault();
        Destroy(deleteCode);
    }
}
