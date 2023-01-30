using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * If player has the list open, cannot interact with items.
 * 
 * List will update as each task is complete.
 * 
 */

public class TaskManager : MonoBehaviour
{
    [Header("Scripts")]
    TodoListDisplay listDisplayScript;
    PickUpObject hasItemScript;

    [Header("List Images")]
    //public Image listImage; //ui
    public Sprite sweepComplete; //change image due to task completion

    void Start()
    {
        listDisplayScript = FindObjectOfType<TodoListDisplay>();
        hasItemScript = FindObjectOfType<PickUpObject>();
    }

    void Update()
    {
        HasTaskItem();
        FinishedSweeping();
    }

    /*
     * if player is holding a task item,
     * player cannot open to-do list
     */
    private void HasTaskItem()
    {
        /*
        if (hasItemScript.hasBroom == true)
        {
            listDisplayScript.displayList.enabled = false;
        }
        */
    }

    /*
     * if all areas of the florr is cleaned,
     * change sprite so that the checkmark is next to the sweep task.
     */
    private void FinishedSweeping()
    {
        if (GameObject.FindGameObjectsWithTag("DirtyFloor").Length == 0)
        {
            listDisplayScript.displayList.sprite = sweepComplete;
        }
    }
}
