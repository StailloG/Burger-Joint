using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
  [SerializeField] private KitchenObjectSO kitchenObjectSo;
 
  public override void Interact(PlayerMovement player)
  {
    if(!HasKitchenObject())
    {
      //^there is no kitchen object on the counter
      if (player.HasKitchenObject())
      {
        //drop object that player has and put it on the coujnter
        player.GetKitchenObject().SetKitchenObjectParent(this);
      }
      else
      {
        //if player doesnt have a kitchen object on hand
      }
    }
    else
    {
      //there is already a kitchen object on the counter
      if (player.HasKitchenObject())
      {
        
      }
      else
      {
        //if player does not have a kitchen object and there is a kitchen obkect on the counter 
        //place the the object on the counter to the player
        
        GetKitchenObject().SetKitchenObjectParent(player);
      }
    }
    
  }

 
}
