using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * a script that should determine which dialogue is being played
 * using bools:
 *  - before picking up todo list
 *  - after picking up todo list
 *  - after todo list is complete
 */
public class CoworkerDialogueOrder : MonoBehaviour
{
    [Header("Scripts")]
    public TodoListDisplay pickUpList;
    public DialogueTrigger dialogueTriggerScript;
    public CheckmarkCompletion list;
    public GBStartWalking gbWalking;

    [Header("Bools")]
    //public bool firstDialogue = false; //before picking up todo list
    public bool endedFirstDialogue = false;
    public bool secondDialogue = false; //after picking up todo list
    public bool thirdDialogue = false; //after todo list is complete

    [Header("GameObjects")]
    public GameObject firstDialogueTrigger;
    public GameObject secondDialogueTrigger;
    public GameObject thirdDialogueTrigger;
    public void Update()
    {
        //first dialogue
        if (endedFirstDialogue == true)
        {
            Debug.Log("can now pick up todo list");
            CanNowPickupTodoList();

            //DuringTodoList();
        }
        //second dialogue
        if (pickUpList.proceed == true)
        {
            Debug.Log("during todo list");
            DuringTodoList();
        }
        if (list.tasksCompleted == true)
        {
            //third dialogue
            Debug.Log("after completing todo list");
            AfterTodoList();
        }
    }

    public void CanNowPickupTodoList()
    {
        pickUpList.proceed = true;
    }

    public void DuringTodoList()
    {
        //set new convo
        //disable the 1st dialogue on coworker
        firstDialogueTrigger.SetActive(false);
        secondDialogueTrigger.SetActive(true);
    }

    public void AfterTodoList()
    {
        //set final convo
        //disable the 1st & 2nd dialogue on coworker
        firstDialogueTrigger.SetActive(false);
        secondDialogueTrigger.SetActive(false);
        thirdDialogueTrigger.SetActive(true);

        //GB can now walk to restaurant after ~5-10 seconds
        gbWalking.WalkIntoRestaurant();
    }
}
