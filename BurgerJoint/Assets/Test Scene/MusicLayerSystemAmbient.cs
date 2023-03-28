using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicLayerSystemAmbient : MusicSystemBase
{
  [Header("Music Layer System Ambient set up")]
  [Tooltip("How many layers you want to start playing")]
  [SerializeField] private int startingSourcesToPlay = 1;

  [Tooltip("This is the amount of changes when the Randomization function starts, a source fading in or out counts as one change")]
  [SerializeField][Range(1, 50)] private int amountOfChanges = 1;
  
  [Tooltip("If NOT random, this is the interval in seconds it takes to change")] 
  [SerializeField] private float mainRandomIntervalTime = 5f;
  
  [Tooltip("Do you want the main randomization function to happen at random intervals?")]
  [SerializeField] private bool doRandomTimeChange = false;
  [Tooltip("If do random Time change is on, this is the max interval in seconds it takes to change")] 
  [SerializeField] private float maxRandomIntervalTime = 5f;
  [Tooltip("If do random Time change is on, this is the min interval in seconds it takes to change")] 
  [SerializeField] private float minRandomIntervalTime = 5f;
  
  
  
  
  [Tooltip("This is if you want the fade in and fade out times to be randomized as well")]
  [SerializeField] private bool randomizeFadeTime = false;
  [Tooltip(" this is the max fade in seconds it takes to change")] 
  [SerializeField] private float maxRandomFadeTime = 5f;
  [Tooltip(" this is the min fade in seconds it takes to change")] 
  [SerializeField] private float minRandomMinTime = 5f;


  private List<AudioSource> mutedAudioSources;
  
  private void Awake()
  {
    Init();
    mutedAudioSources = new List<AudioSource>();
  }

  public override void StartMusicSystem()
  {
    //if music system already on, dont continue 
    if (musicSystemIsOn) return;
    musicSystemIsOn = true;
    /*
    audioSources[0].Play();
    
    
    //fade in first AudioSources
    StartCoroutine(FadeInMusicSource(audioSources[0],fadeInTime));
  */
    foreach (AudioSource source in audioSources)
    {
      source.Play();
      source.mute = true;
      if (source == null)
      {
        Debug.Log("source was null");
      }
      mutedAudioSources.Add(source);
    }

    if (amountOfChanges > audioSources.Length)
    {
      amountOfChanges = audioSources.Length - 1;
    }

    for (int i = 0; i < amountOfChanges; i++)
    {
      //choose a source from muted 
      int chosenMutedAudioSource = Random.Range(0, mutedAudioSources.Count);
      //if muted, Fade it in, remove from muted 
      if (mutedAudioSources[chosenMutedAudioSource].mute == true)
      {
        StartCoroutine(FadeInMusicSource(mutedAudioSources[chosenMutedAudioSource], fadeInTime));
        mutedAudioSources.Remove(mutedAudioSources[chosenMutedAudioSource]);
      }
      else
      {
        // else choose another source, if muted then fade it in and remove from muted 
        Debug.Log("tried to fade in a source taht was already playing");
      }
      
     
    }
    

  }


  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.G))
    {
      StartMusicSystem();
    }
  }
}
