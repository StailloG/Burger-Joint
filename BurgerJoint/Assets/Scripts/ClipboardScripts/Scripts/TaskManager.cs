using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * If player has the list open, cannot interact with items.
 * List will update as each task is complete.
 * 
 * NOT COMPLETE
 */

public class TaskManager : MonoBehaviour
{
    [Header("Scripts")]
    TodoListDisplay listDisplayScript;
    PickUpObject hasItemScript;

    void Start()
    {
        listDisplayScript = FindObjectOfType<TodoListDisplay>();
        hasItemScript = FindObjectOfType<PickUpObject>();
    }

    void Update()
    {
        HasTaskItem();
    }

    /*
     * if player is holding a task item,
     * player cannot open to-do list
     */
    private void HasTaskItem()
    {
        if (hasItemScript.hasBroom == true)
        {
            listDisplayScript.displayList.enabled =false;
        }
    }
}
