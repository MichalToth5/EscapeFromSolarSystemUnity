using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxChannel : MonoBehaviour
{
    public GameObject audioObject;
    public AudioSource audioSource;
    public bool loop;

    public SfxChannel(GameObject audioObject, AudioSource audioSource, bool loop)
    {
        this.audioObject = audioObject;
        this.audioSource = audioSource;
        this.loop = loop;
    }
}
