using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
 * Displays to-do list as a UI canvas when player is near clipboard & presses spacebar.
 * The to-do list will not go away until the player presses 'E'.
 */

public class TodoListDisplay : MonoBehaviour
{
    [Header("GameObjects")]
    public TextMeshProUGUI text;
    public Image displayList;

    [Header("Testing")]
    [SerializeField] private bool isPlayerNear = false;


    void Start()
    {
        text.gameObject.SetActive(false);
        displayList.enabled = false;
    }

    void Update()
    {
        if (isPlayerNear == true)
        {
            OpenListFromClipboard();
        }

        EscFromList();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerNear = true;
            text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerNear = false;
        text.gameObject.SetActive(false);
    }

    //if player is opening list from clipboard
    private void OpenListFromClipboard()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            displayList.enabled = true;
            text.gameObject.SetActive(false);
        }
    }

    //list will disappear when player presses e
    private void EscFromList()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            displayList.enabled = false;
        }
    }
}
