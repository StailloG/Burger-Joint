using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueDialogue : MonoBehaviour
{
    public DialogueManager contDialogueMethod;
    public DialogueTrigger startBool;

    // Update is called once per frame
    void Update()
    {
        if (startBool.start == true && Input.GetKeyDown(KeyCode.Space))
        {
            contDialogueMethod.DisplayNextSentence();
        }
        
    }
}
