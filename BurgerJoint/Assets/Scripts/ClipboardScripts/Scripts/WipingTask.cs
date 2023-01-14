using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Whenever player picks up the cloth, tables in the restaurant will start to glow. - INCOMPLETE
 * The glowing areas indicate where the player will have to wipe clean.
 * Once the player cleans the area by pressing spacebar, the glow will disappear.
 * 
 * Once all glowing areas disappear, the player has completed wiping the tables task.
 */

public class WipingTask : MonoBehaviour
{
    public Outline outline;
    PickUpObject hasItemScript;
    [SerializeField] private bool isPlayerNear = false;

    private void Start()
    {
        hasItemScript = FindObjectOfType<PickUpObject>();
    }

    void Update()
    {
        if (isPlayerNear == true && Input.GetKeyDown(KeyCode.Space))
        {
            CleanTable();
        }

        //ActivateTableGlow(); doesn't seem to work
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerNear = false;
    }

    private void CleanTable()
    {
        outline.enabled = false;
    }

    //doesn't seem to work
    //public void ActivateTableGlow()
    //{
    //    if (hasItemScript.hasCloth == true)
    //    {
    //        outline.enabled = false;
    //    }
    //}
}
