using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContinue : MonoBehaviour
{
    public DialogueTrigger triggerScript;

    void Update()
    {
        if (triggerScript.inConvo == true && Input.GetKeyDown(KeyCode.E)) //if space doesn't work, try e
        {
            TriggerNextDialogue();
        }
    }

    public void TriggerNextDialogue()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
}
