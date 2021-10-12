using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioToPlay;
    public bool isDeactivating = false;

    void Start()
    {
        isDeactivating = false;
        audioToPlay.Play();
    }

}
