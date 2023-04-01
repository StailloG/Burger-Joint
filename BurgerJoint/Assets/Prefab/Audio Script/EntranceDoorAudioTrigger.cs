using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoorAudioTrigger : MonoBehaviour
{
    [SerializeField] private CustomerDoorBellAudio cdba;
    private void OnTriggerEnter(Collider other)
    {

        
        //if npc or player (potentially if monster too)
        if (other.gameObject.GetComponent<NPCAnimation>() || other.gameObject.GetComponent<PlayerMovement>())
        {
            cdba.PlayEntryGreeting();
        }
    }

   


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<NPCAnimation>() || other.gameObject.GetComponent<PlayerMovement>())
        {
           
            cdba.PlayExitGreeting();
        }
    }
}
