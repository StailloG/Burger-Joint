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


    // Start is called before the first frame update
    void Start()
    {
        canSpeak = false;
        proceed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpeak == true && Input.GetKeyDown(KeyCode.E))
        {
            Introduction();
        }
    }

    void Introduction()
    {
        //TODO: coworker dialogue
        Debug.Log("Can now pick up to do list!");
        proceed = true;
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
