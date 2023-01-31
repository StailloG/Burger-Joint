using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script controls if the outline is on or off. Outline and OutlineManager needs to be on the same object
/// </summary>
public class OutlineManager : MonoBehaviour
{
    private Outline outlineScript;
    [SerializeField] private GameObject stainVisual;

    private void Awake()
    {
        outlineScript = GetComponent<Outline>();
    }

    public void ShowOutline()
    {
       // outlineScript.enabled = true;
        if(stainVisual)
            stainVisual.gameObject.SetActive(true);
    }
    
    public void HideOutline()
    {
       // outlineScript.enabled = false;
        if(stainVisual)
            stainVisual.gameObject.SetActive(false);

    }
}
