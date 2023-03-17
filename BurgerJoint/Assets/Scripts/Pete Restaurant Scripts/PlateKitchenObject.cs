using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{

    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSO;

    private List<KitchenObjectSO> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSo)
    {
        if (!validKitchenObjectSO.Contains(kitchenObjectSo))
        {
            return false;
        }
        
        if (kitchenObjectSOList.Contains(kitchenObjectSo))
        {
            return false;
        }
        else
        {
            kitchenObjectSOList.Add(kitchenObjectSo);
            return true;
        }
       
    }
}
