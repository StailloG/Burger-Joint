using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Scripts")]
    public Dialogue dialogue;

    [Header("Bools")]
    public bool inConvo = false;
    public bool isNear = false;

    void Update()
    {
        if (isNear == true && Input.GetKeyDown(KeyCode.Space))
        {
            TriggerDialogue();
            inConvo = true;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Near coworker");
            isNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isNear = false;
    }
}
