using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
   [SerializeField] private TrashCounterAudio trashCounterAudio;
   public override void Interact(PlayerMovement player)
   {
      if (player.HasKitchenObject())
      {
         if(trashCounterAudio) trashCounterAudio.PlayTrashAudio();
         player.GetKitchenObject().DestroySelf();
      }
   }
}
