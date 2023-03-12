using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.PlayerLoop;

/// <summary>
/// A script that automatically spawns audiosources and creates a user controlled music system with layers. 
/// </summary>
public class MusicLayerSystem : MonoBehaviour
{
  [SerializeField] private AudioClip[] audioStems;
  
  [SerializeField][Range(0.01f, 12f)] private float fadeInTime = 1.5f;
  [SerializeField][Range(0.01f, 12f)] private float fadeOutTime = 1.5f;
  //set your audiosources to one music group
  public AudioMixerGroup musicMixerGroup; 
  
  private AudioSource[] audioSources;
  
  private int currentIntensity = 0;//currentIntensity = 0 is the first music layer playing  
  
  private int amountOfStems;
  private float musicVolumeMax = 1f;

  private void Awake()
  {
    amountOfStems = audioStems.Length;

    if (amountOfStems <= 0)
    {
      Debug.LogWarning("No audio clips added to the audio stems!!");
      return; 
    }
    audioSources = new AudioSource[amountOfStems];
    
    Init();
  }

  private void Init()
  {
    for (int i = 0; i < amountOfStems; i++)
    {
      //spawn all the audiosources
      AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
    
      //configure the audioSource properties 
      newAudioSource.playOnAwake = false;
      newAudioSource.loop = true;

      //assign clip to the audioSource
      newAudioSource.clip = audioStems[i];

      newAudioSource.outputAudioMixerGroup = musicMixerGroup;
      
      //add to the audioSources array
      audioSources[i] = newAudioSource;
    }
  }
  
  //start 
  public void StartMusicSystem()
  {

    audioSources[0].Play();
    //fade in first audiosource
    StartCoroutine(FadeInMusicStem(audioSources[0],fadeInTime));

    for (int i = 1; i < audioSources.Length; i++)
    {
      audioSources[i].Play();
      audioSources[i].mute = true;
    }

    currentIntensity = 0;
  }
  
  //stop 
  
  
  //increase intensity 
  public void IncreaseIntensity()
  {
    if (currentIntensity >= amountOfStems - 1)
    {
      Debug.LogWarning("MusicLayerSystem: Already reached highest intensity");
      return;
    }

    currentIntensity++;

    StartCoroutine(FadeInMusicStem(audioSources[currentIntensity], fadeInTime));
    
  }
  
  
  //decrease intensity 
  public void DecreaseIntensity()
  {
    if (currentIntensity <= 0)
    {
      Debug.LogWarning("MusicLayerSystem: Already reached lowest intensity");
      return;
    }
    StartCoroutine(FadeOutMusicStem(audioSources[currentIntensity], fadeOutTime));
    currentIntensity--;

   
    
  }
  
  
  //fade in 
  //What is an ienumerator 
  private IEnumerator FadeInMusicStem(AudioSource activeSource, float transitionTime)
  {
    activeSource.volume = 0.0f;
    activeSource.mute = false;

    for (float t = 0.0f; t <= transitionTime; t += Time.deltaTime)
    {
      activeSource.volume = (t / transitionTime) * musicVolumeMax;
      yield return null;
    }

    activeSource.volume = musicVolumeMax; 

  }
  //fade out 
  private IEnumerator FadeOutMusicStem(AudioSource activeSource, float transitionTime)
  {

    for (float t = 0.0f; t <= transitionTime; t += Time.deltaTime)
    {
      activeSource.volume = (musicVolumeMax -((t / transitionTime) * musicVolumeMax));
      yield return null;
    }
    activeSource.mute = true;

    activeSource.volume = musicVolumeMax; 

  }
}
