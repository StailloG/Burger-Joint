using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{

    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;
    public override void Interact(PlayerMovement player)
    {
        if(!HasKitchenObject())
        {
            //^there is no kitchen object on the counter
            if (player.HasKitchenObject())
            {
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    //drop object that player has and put it on the coujnter
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
               
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


    public override void InteractAlternate(PlayerMovement player)
    {
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
            GetKitchenObject().DestroySelf();
           
            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
           
        }
    }


    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSo in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSo.input == inputKitchenObjectSO)
            {
                return true;
            }
        }

        
        return false;
    }
    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSo)
    {
        foreach (CuttingRecipeSO cuttingRecipeSo in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSo.input == inputKitchenObjectSo)
            {
                return cuttingRecipeSo.output;
            }
        }

        
        return null;
    }
}
