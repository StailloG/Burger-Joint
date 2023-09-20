using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLayout : MonoBehaviour
{
    [SerializeField] private bool playerNear = false;
    public Dialogue dialogueScript;

    void Update()
    {
        if (playerNear == true & Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Can now speak to coworker");
            dialogueScript.ContinueText();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            playerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            playerNear = false;
        } 
    }
}
