using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{

    private enum State
    {
        Idle,
        Frying,
        Fried,
        Burned
    }
    
    
    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;

    private State currentState = State.Idle;
    private float fryingTimer;
    private FryingRecipeSO fryingRecipeSO;
    private void Update()
    {
        if (HasKitchenObject())
        {
            switch (currentState)
            {
                case State.Idle:
                break;
                
                case State.Frying:
                    fryingTimer += Time.deltaTime;
           
                    if (fryingTimer > fryingRecipeSO.fryingTimerMax)
                    {
                        fryingTimer = 0f;
                        GetKitchenObject().DestroySelf();
                        KitchenObject.SpawnKitchenObject(fryingRecipeSO.output, this);
                        currentState = State.Fried;
                    }
                    break;
            
                case State.Fried:
                    break;
            
                case State.Burned:
                    break;
            }
            
        }
    }


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
                    fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    currentState = State.Frying;
                    fryingTimer = 0;
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
    
    
    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        
        FryingRecipeSO fryingRecipeSo = GetFryingRecipeSOWithInput(inputKitchenObjectSO);


        return fryingRecipeSo != null;
    }
    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSo)
    {
        FryingRecipeSO fryingRecipeSo = GetFryingRecipeSOWithInput(inputKitchenObjectSo);
        if (fryingRecipeSo != null)
        {
            return fryingRecipeSo.output;
        }
        else
        {
            return null;
        }
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (FryingRecipeSO fryingRecipeSo in fryingRecipeSOArray)
        {
            if (fryingRecipeSo.input == inputKitchenObjectSO)
            {
                return fryingRecipeSo;
            }
        }

        
        return null;
    }
}
