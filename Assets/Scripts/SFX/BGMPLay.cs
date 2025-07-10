using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPLay : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
