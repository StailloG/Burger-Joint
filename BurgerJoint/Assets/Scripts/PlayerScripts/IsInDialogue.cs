using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInDialogue : MonoBehaviour
{

    public PlayerMovement playerMove;
    public DialogueTrigger dTrigger; //first dialogue
    public PlayerMovement playerMov;

    void Update()
    {
        //if (dTrigger.inConvo == true)
        //{
        //    var check = !playerMove.IsMoving();
        //    check = false;
        //    Debug.Log("player cannot move");
        //}
        //else
        //{
        //    var check = !playerMove.IsMoving();
        //    check = true;
        //}

        ConversatingWithCoworker();

        if (playerMov.playerIsInMovement == true)
        {
            //Debug.Log("player movement is true");
        }
    }

    public void ConversatingWithCoworker()
    {
        //player in convo (1st dialogue)
        if (dTrigger.inConvo == true)
        {
            playerMov.playerIsInMovement = false;
            this.transform.position = new Vector3(-2.430237f, 1.121925f, -25.76964f);
        }
        //player not in convo
        if (dTrigger.inConvo == false)
        {
            playerMov.playerIsInMovement = true;
        }
    }
}
