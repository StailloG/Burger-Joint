using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ContainerCounter : BaseCounter
{

    public event EventHandler OnPlayerGrabbedObject; 
    [SerializeField] private KitchenObjectSO kitchenObjectSo;
    [SerializeField] private AudioSource source;
    [SerializeField] private List<AudioClip> openingClips;

    public override void Interact(PlayerMovement player)
    {
        if (!player.HasKitchenObject())
        {
            PlayOpenCabinetSFX();
            KitchenObject.SpawnKitchenObject(kitchenObjectSo, player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }


    private void PlayOpenCabinetSFX()
    {
        var clip = openingClips[Random.Range(0, openingClips.Count)];
        source.PlayOneShot(clip);
    }
   
}
