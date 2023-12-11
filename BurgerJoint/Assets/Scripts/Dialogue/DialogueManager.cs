using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Text")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    [Header("Dialogue Objects")]
    public GameObject displayBox;
    public GameObject displayName;
    public GameObject displayDialogue;

    public int order = 0;

    private Queue<string> sentences;

    public DialogueTrigger dialogueTriggerScript;

    void Start()
    {
        sentences = new Queue<string>();

        DialogueSetInactive();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        DialogueSetActive();

        Debug.Log("Starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;

        sentences.Clear(); //clear prev convo

        foreach (string sentence in dialogue.sentences) //(string item in collection)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) //if reached end of convo/Queue
        {
            EndDialogue();
            return; //return out of the rest of the function
        }

        //if there's still convo left to say
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation.");
        DialogueSetInactive();
        FindObjectOfType<DialogueTrigger>().inConvo = false;
        dialogueTriggerScript.inConvo = false;

        order += 1;
    }

    public void DialogueSetInactive()
    {
        displayBox.SetActive(false);
        displayName.SetActive(false);
        displayDialogue.SetActive(false);
    }

    public void DialogueSetActive()
    {
        displayBox.SetActive(true);
        displayName.SetActive(true);
        displayDialogue.SetActive(true);
    }
}
