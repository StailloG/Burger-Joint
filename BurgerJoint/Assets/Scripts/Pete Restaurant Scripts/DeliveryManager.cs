using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{//7:13:15
    private List<RecipeSO> waitingRecipeSOList;

    [SerializeField] private _RecipeSOList recipeListSO;

    public static DeliveryManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}
