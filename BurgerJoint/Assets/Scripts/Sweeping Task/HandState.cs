using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is attached to the Player to determine what the player is holding,
/// if anything.
/// Uses the PickupStainsTaskType script.
/// </summary>

public class HandState : MonoBehaviour
{
    public PickupType CurrentHandState = PickupType.NONE;
}
