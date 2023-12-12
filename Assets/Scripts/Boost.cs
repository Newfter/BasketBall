using System;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public AudioSource boostAudio;

    public void OnTriggerEnter2D(Collider2D other)
    {
        boostAudio.Play();
    }
}

