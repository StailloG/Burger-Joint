using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainsActionTask : MonoBehaviour
{
    public List<GameObject> stains;

   public void CleanStains()
    {
        foreach (GameObject area in stains)
        {
            area.GetComponent<StainsManager>().RemoveStains();
        }
    }


    public void RemoveSelf(CheckActionAreas checkActionAreas)
    {
        stains.Remove(checkActionAreas.gameObject);
    }
}
