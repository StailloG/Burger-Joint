using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerFootsteps : MonoBehaviour
{
    private AudioSource audioSource;
    public List<AudioClip> tileFootsteps;
    public List<AudioClip> carpetFootsteps;
    public List<AudioClip> grassFootsteps;
    [SerializeField] private FootstepType currentFootstepType;
    
    [Header("Random Params")] 
    [SerializeField] [Range(0.01f, 0.99f)] private float minVolume = 0.8f;
    [SerializeField] [Range(0.02f, 1f)] private float maxVolume = 1f;

    [SerializeField] [Range(0.25f, 0.75f)] private float stepCooldown = 0.5f;
    
    private PlayerMovement pm;

    private float timer = 0;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        pm = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        
        if(timer < stepCooldown) return;
        if (!pm.IsMoving()) return;
        
        PlayFootstepAudio();
        timer = 0;
    }

    private void PlayFootstepAudio()
    {
        var clip = DetermineFootstepClip();
       
        
        audioSource.volume = Random.Range(minVolume, maxVolume);
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(clip);
    }

    private AudioClip DetermineFootstepClip()
    {
        switch (currentFootstepType)
        {
            case FootstepType.TILE:
                return tileFootsteps[Random.Range(0, tileFootsteps.Count)];
                break;
            case FootstepType.GRASS:
                return grassFootsteps[Random.Range(0, grassFootsteps.Count)];
                break;
            case FootstepType.CARPET:
                return carpetFootsteps[Random.Range(0, carpetFootsteps.Count)];
                break;
            default:
                Debug.Log("Default footstep being called");
                return tileFootsteps[Random.Range(0, tileFootsteps.Count)];
                break;
            
        }
    }
}


public enum FootstepType
{
    NONE,
    CARPET,
    TILE,
    GRASS
}
