using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script removes the stains from the floor when the player sweeps them up.
/// </summary>

public class StainsManager : MonoBehaviour
{
    public void RemoveStains()
    {
        gameObject.SetActive(false);
    }
}