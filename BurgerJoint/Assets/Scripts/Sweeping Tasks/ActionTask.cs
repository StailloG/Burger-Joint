using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTask : MonoBehaviour
{
    
    //all action areas must have outline nad outline manager scripts
    public List<GameObject> actionAreas;

    private void Start()
    {
        
        HideAllOutLines();
     
    }


    public void ShowAllOutlines()
    {
        foreach (GameObject area in actionAreas)
        {
            area.GetComponent<OutlineManager>().ShowOutline();
        }
    }
    
    public void HideAllOutLines()
    {
        foreach (GameObject area in actionAreas)
        {
            area.GetComponent<OutlineManager>().HideOutline();
        }
    }

    public void RemoveSelf(CheckActionAreas checkActionAreas)
    {
        actionAreas.Remove(checkActionAreas.gameObject);
    }
}
