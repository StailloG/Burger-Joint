using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineManager : MonoBehaviour
{
    private Outline outlineScript;


    private void Awake()
    {
        outlineScript = GetComponent<Outline>();
    }

  

    public void ShowOutline()
    {
        outlineScript.enabled = true;
    }
    
    public void HideOutline()
    {
        outlineScript.enabled = false;
    }
}
