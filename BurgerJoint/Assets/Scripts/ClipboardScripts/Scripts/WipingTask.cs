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
    [Header("Activate Sweep Task")]
    PickUpObject hasItemScript;
    public GameObject glowArea;

    void Start()
    {
        hasItemScript = FindObjectOfType<PickUpObject>();

        GetComponent<MeshRenderer>().enabled = false;

    }

    void Update()
    {
        ActivateGlow();
    }
    public void ActivateGlow()
    {
        if (hasItemScript.hasCloth == true)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
