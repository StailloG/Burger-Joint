using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    [SerializeField] private RecipeSO personRecipe;
    [SerializeField] private OrderBoardUI orderBoardUI;
    public override void Interact(PlayerMovement player)
    {
        if (player.HasKitchenObject())
        {
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                //logic to see if this was the correct recipe 
                RecipeFeedback(plateKitchenObject);
                player.GetKitchenObject().DestroySelf();
            }
        }
    }

    private void RecipeFeedback(PlateKitchenObject plateKitchenObject)
    {
        //comparing whats on the plate and what the person ordered
        
       

       if (plateKitchenObject.GetKitchenObjectSOList().Count != personRecipe.kitchenObjectSOList.Count)
       {
           //calculate negative score, i dont think return is needed technically 
          
           Debug.Log("bruv this isnt the right amount of ingredients");
       }

       bool plateContentsMatchesRecipe = true;

       
       /*
        * This nested forloop is for checking if the ingredients are similar to the plate object 
        */
       foreach (KitchenObjectSO recipeKitchenObjectSO in personRecipe.kitchenObjectSOList)
       {
           bool ingredientFound = false;

           foreach (KitchenObjectSO plateKitchenObjectSo in plateKitchenObject.GetKitchenObjectSOList())
           {
               if (plateKitchenObject == recipeKitchenObjectSO)
               {
                   ingredientFound = true;
                   break;
               }
           }

           if (!ingredientFound)
           {
               //negative deduction, this is happending every iteration, you shoudl wait until last interation to say it 
               plateContentsMatchesRecipe = false;
           }
           else
           {
               //positive points
               Debug.Log("ok this ingredient was the one i wanted ");
           }
           
       }
       
       
       //calculate the points
       //say feedback based on the points
       
        
        orderBoardUI.ClearOrder();
    }

    public void SendOrder()
    {
        orderBoardUI.NewOrder(personRecipe);
        
    }
}
