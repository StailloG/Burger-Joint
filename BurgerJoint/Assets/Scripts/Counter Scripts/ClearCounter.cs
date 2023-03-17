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
        if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
        {
         
          if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
          {
            GetKitchenObject().DestroySelf();

          }
        }
        else
        {
          if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
          {
            if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
            {
              player.GetKitchenObject().DestroySelf();
            }
          }
        }
      }
      else
      {
        //if player does not have a kitchen object and there is a kitchen obkect on the counter 
        //place the the object on the counter to the playe
        GetKitchenObject().SetKitchenObjectParent(player);
      }
    }
    
  }

 
}
