using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool inConvo = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TriggerDialogue(); //starts conversation
            inConvo = true;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
