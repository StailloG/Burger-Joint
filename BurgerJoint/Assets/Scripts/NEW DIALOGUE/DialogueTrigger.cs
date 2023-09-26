using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueBrackeys dialogue;

    public NearNPC npc;

    public bool start = false;

    public void Update()
    {
        if (npc.playerNear == true && Input.GetKeyDown(KeyCode.Space))
        {
            TriggerDialogue();
            start = true;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
