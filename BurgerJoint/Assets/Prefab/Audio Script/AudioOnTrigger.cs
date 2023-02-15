using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip triggerEnterClip;
    [SerializeField] private AudioClip triggerExitClip;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerEnterClip == null) return;
        if(other.GetComponent<PlayerMovement>() == null) return;
        
        audioSource.PlayOneShot(triggerEnterClip);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (triggerExitClip == null) return;
        if(other.GetComponent<PlayerMovement>() == null) return;
        
        audioSource.PlayOneShot(triggerExitClip);
    }
}
