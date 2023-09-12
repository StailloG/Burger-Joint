using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroCoworkerDialogue : MonoBehaviour
{
    [Header("Used in other Scripts")]
    public bool proceed;
    public bool inDialogueMode;

    [Header("Variable")]
    [SerializeField] private bool canSpeak;
    [SerializeField] private int canOnlyPressEOnce = 0;
    [SerializeField] private bool questionPlayer = false;

    [Header("Scripts")]
    public Dialogue dialogue;
    //public CheckmarkCompletion listComplete;

    void Start()
    {
        canSpeak = false;
        proceed = false;
        inDialogueMode = false;
        questionPlayer = false;
    }

    //first time speaking to coworker
    void Update()
    {
        if (canSpeak == true && Input.GetKeyDown(KeyCode.E) & canOnlyPressEOnce == 0)
        {
            inDialogueMode = true;
            IntroductionDialogue();
            canOnlyPressEOnce++;
        }
    }

    void IntroductionDialogue()
    {
        dialogue.StartDialogue();

        Debug.Log("Can now pick up to do list!");
        proceed = true;
    }

    void ListNotCompleteDialogue()
    {

        Debug.Log("You haven't completed your tasks yet");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSpeak = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSpeak = false;
        }
    }
}
