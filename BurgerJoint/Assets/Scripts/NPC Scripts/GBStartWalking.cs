using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBStartWalking : MonoBehaviour
{
    public bool GBCanNowWalkIn = false;

    public void WalkIntoRestaurant()
    {
        StartCoroutine(WalkIntoRestaurantSecondss(5f));
    }

    public IEnumerator WalkIntoRestaurantSecondss(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GBCanNowWalkIn = true;
    }
}
