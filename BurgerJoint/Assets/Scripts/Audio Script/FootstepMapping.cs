using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script uses box colliders and change the type of footstep to be called when the player walks past it
/// </summary>
public class FootstepMapping : MonoBehaviour
{ 
    [SerializeField] private FootstepType entryFootstepType;
    [SerializeField] private FootstepType exitFootstepType;
    
    
    private PlayerFootsteps playerFootsteps;
    private void Awake()
    {
        playerFootsteps = FindObjectOfType<PlayerFootsteps>();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
            playerFootsteps.SetFootstepType(entryFootstepType);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
            playerFootsteps.SetFootstepType(exitFootstepType);
    }
}
