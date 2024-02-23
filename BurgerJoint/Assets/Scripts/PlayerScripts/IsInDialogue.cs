using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInDialogue : MonoBehaviour
{
    public DialogueTrigger dTrigger; //first dialogue
    public PlayerMovement playerMov;

    void Update()
    {
        ConversatingWithCoworker();
    }

    public void ConversatingWithCoworker()
    {
        //player in convo (1st dialogue)
        if (dTrigger.inConvo == true)
        {
            playerMov.playerIsInMovement = false;
            //new player pos
            this.transform.position = new Vector3(-2.430237f, 1.121925f, -25.76964f);
        }
        //player not in convo
        if (dTrigger.inConvo == false)
        {
            playerMov.playerIsInMovement = true;
        }
    }
}
