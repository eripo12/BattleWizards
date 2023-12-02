using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : MonoBehaviour
{
    private AudioSource audioSource;
     private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySound();
    }

    public void PlaySound()
    {
        if(audioSource != null)
        {
            audioSource.Play();
        }
    }

    public void DestroyEffect()
    {
        Destroy(gameObject);
    }
}

