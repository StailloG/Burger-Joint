using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
 * Displays to-do list as a UI canvas when player is near clipboard & presses spacebar.
 * After player grabs to-do list from clipboard, list can be opened from anywhere by pressing 'C'.
 * The to-do list will not go away until the player presses 'E'.
 * 
 * Attach script to clipboard gameobject.
 */

public class TodoListDisplay : MonoBehaviour
{
    [Header("GameObjects")]
    public TextMeshProUGUI text;
    public Image displayList;
    public GameObject listOnClipboard;

    [Header("Testing")]
    [SerializeField] private bool isPlayerNear = false;
    [SerializeField] private bool firstTimeGrabbingList = false;


    void Start()
    {
        text.gameObject.SetActive(false);
        displayList.enabled = false;
    }

    void Update()
    {
        if (isPlayerNear == true && firstTimeGrabbingList == false)
        {
            OpenListFromClipboard();
        }

        OpenListFromAnywhere(); //after opening list from clipboard, player can open list from anywhere

        EscFromList();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && firstTimeGrabbingList == false)
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

            firstTimeGrabbingList = true;
            Destroy(listOnClipboard); //destroys original list on clipboard
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

    //player can now open list from anywhere after grabbing it from the clipboard first
    private void OpenListFromAnywhere()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            displayList.enabled = true;
        }
    }
}
