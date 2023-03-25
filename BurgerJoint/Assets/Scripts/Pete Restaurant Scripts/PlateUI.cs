using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObject_IngredientAdded; 
    }

    private void PlateKitchenObject_IngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        string whatsInPlateText = "You have ";
        string itemsInPlateText = String.Empty;
        
        foreach (KitchenObjectSO kitchenObjectSo in plateKitchenObject.GetKitchenObjectSOList())
        {
            itemsInPlateText += kitchenObjectSo.objectName;
        }

        if (itemsInPlateText == String.Empty)
        {
            itemsInPlateText = "nothing";
        }


        whatsInPlateText += itemsInPlateText;
        whatsInPlateText += " in your plate!";
        Debug.Log(whatsInPlateText);
    }
}
