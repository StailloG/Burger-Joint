using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Simple script that sets the audio mixers for the wind ambience based on if the player is inside or outside
/// </summary>
public class AudioAmbienceManager : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot defaultMix;
    [SerializeField] private AudioMixerSnapshot insideMix;
    [SerializeField] private float transitionTime = 2f;
    private int currentState;

    public void EnterTrigger()
    {
        currentState++;
        OnTriggerCollide();
    }

    public void ExitTrigger()
    {
        currentState--;
        OnTriggerCollide();
    }

/// <summary>
/// The idea is that when player enters a trigger of the room, it will increase the count of the state by 1. exiting
/// a room decreases the count by one. if state is 0, then player is outside, else they are inside 
/// </summary>
    private void OnTriggerCollide()
    {
        if(currentState ==0 )
            defaultMix.TransitionTo(transitionTime);
        else 
            insideMix.TransitionTo(transitionTime);
    }
}
