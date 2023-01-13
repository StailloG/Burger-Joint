using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Whenever player picks up the cloth, tables in the restaurant will start to glow.
 * The glowing areas indicate where the player will have to wipe clean.
 * Once the player cleans the area by pressing spacebar, the glow will disappear.
 * 
 * Once all glowing areas disappear, the player has completed wiping the tables task.
 */

public class WipingTask : MonoBehaviour
{
    [Header("Activate Wipe Task")]
    PickUpObject hasItemScript;
    public Outline outline;

    void Start()
    {
        hasItemScript = FindObjectOfType<PickUpObject>();
        
        outline.enabled = false;
    }

    void Update()
    {
        ActivateTable();
    }
    private void ActivateTable()
    {
        if (hasItemScript.hasCloth == true)
        {
            outline.enabled = true;
        }
        else
        {
            outline.enabled = false;
        }
    }
}
