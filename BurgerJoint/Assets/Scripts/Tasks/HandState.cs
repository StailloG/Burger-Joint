using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is attached to the Player to determine what the player is holding,
/// if anything.
/// Uses the PickupStainsTaskType & IngredientType script.
/// </summary>

public class HandState : MonoBehaviour
{
    //for tasks
    public PickupType CurrentHandState = PickupType.NONE;


    //for serving customers
    public IngredientType ServingHandState = IngredientType.NONE;
}
