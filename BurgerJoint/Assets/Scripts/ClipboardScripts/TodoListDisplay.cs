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
 * 
 * The script TaskManager uses this script.
 */

public class TodoListDisplay : MonoBehaviour
{
    [Header("GameObjects")]
    public TextMeshProUGUI text;
    public Image displayList;
    public GameObject listOnClipboard;

    [Header("Testing")]
    [SerializeField] private bool isPlayerNear = false;
    [SerializeField] private bool grabbedList = false;


    void Start()
    {
        text.gameObject.SetActive(false);
        displayList.enabled = false;
    }

    void Update()
    {
        if (isPlayerNear == true && grabbedList == false)
        {
            OpenListFromClipboard();
        }

        if (grabbedList == true)
        {
            OpenListFromAnywhere(); //after opening list from clipboard, player can open list from anywhere
        }

        EscFromList();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && grabbedList == false)
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

    /*
     * if player is opening list from clipboard for the first time
     * delete the list on the clipboard.
     */
    private void OpenListFromClipboard()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            displayList.enabled = true;
            text.gameObject.SetActive(false);

            grabbedList = true;
            Destroy(listOnClipboard); //destroys original list on clipboard
        }
    }

    //to close the list, player presses e 
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
