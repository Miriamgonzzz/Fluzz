using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrastreRoca : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDraggingSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopDraggingSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
