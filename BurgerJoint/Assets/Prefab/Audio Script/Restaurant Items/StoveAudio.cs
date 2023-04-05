using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveAudio : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] private AudioClip fryingClip;
    [SerializeField] private AudioClip burgerReadyClip;
    [SerializeField] private AudioClip burnedClip;
    [SerializeField] private StoveCounter stoveCounter;
 
    private void Start()
    {
        source = GetComponent<AudioSource>();
        stoveCounter.OnStateChanged += StoveCounterAudio_OnOnStateChanged;
    }

    private void StoveCounterAudio_OnOnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        switch (e.state)
        {
            case StoveCounter.State.Frying:
                //refactor to fade in? 
                source.clip = fryingClip;
                source.Play();
                break;
            case StoveCounter.State.Fried:
                if (source.isPlaying)
                {
                    source.PlayOneShot(burgerReadyClip);
                    //do nothing
                }
                break;
            case StoveCounter.State.Burned:
                source.Stop();
                source.PlayOneShot(burnedClip);
                break;
            default:
                source.Stop();
                break;
                
        }
        
    }
}
