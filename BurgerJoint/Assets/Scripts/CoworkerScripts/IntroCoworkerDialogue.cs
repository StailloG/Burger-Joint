using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroCoworkerDialogue : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private bool canSpeak;

    [Header("Used in other Scripts")]
    public bool proceed;
    public bool inDialogueMode;

    public Dialogue dialogue;
    [SerializeField] private int canOnlyPressEOnce = 0;

    public CheckmarkCompletion listComplete;


    // Start is called before the first frame update
    void Start()
    {
        canSpeak = false;
        proceed = false;
        inDialogueMode = false;
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

    void ListCompleteDialogue()
    {
        dialogue.StartDialogue();
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
