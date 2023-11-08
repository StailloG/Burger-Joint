using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContinue : MonoBehaviour
{
    public DialogueTrigger trigger;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TriggerNextDialogue();
        }    
    }

    public void TriggerNextDialogue()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}
