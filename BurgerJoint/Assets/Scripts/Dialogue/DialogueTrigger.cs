using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool inConvo = false;

    [SerializeField] private bool isNear = false;

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

    public void InConvoFalse()
    {
        inConvo = false;
    }
}
