using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLayerSystemAmbient : MusicSystemBase
{
  [Header("Music Layer System Ambient set up")]
  [Tooltip("How many layers you want to start playing")]
  [SerializeField] private int startingSourcesToPlay = 1;

  [Tooltip("This is the amount of changes when the Randomization function starts, a source fading in or out counts as one change")]
  [SerializeField] private int amountOfChanges = 1;
  
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
  
  
 

  
  private void Awake()
  {
    Init();
  }
    
}
