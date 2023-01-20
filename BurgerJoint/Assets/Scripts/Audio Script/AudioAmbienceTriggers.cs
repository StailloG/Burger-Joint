using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAmbienceTriggers : MonoBehaviour
{
    private AudioAmbienceManager audioAmbienceManager;

    private void Awake()
    {
        audioAmbienceManager = FindObjectOfType<AudioAmbienceManager>();
        if(audioAmbienceManager == null)
            Debug.Log("please remove me from the scene, as there are no Audio Ambience Managers in this scene", gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {

            audioAmbienceManager.EnterTrigger();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            audioAmbienceManager.ExitTrigger();
        }
    }
}
