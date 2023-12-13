using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * a script that should determine which dialogue is being played
 * using bools:
 *  - before picking up todo list
 *  - after picking up todo list
 *  - after todo list is complete
 *  - when customer walks in
 */
public class CoworkerDialogueOrder : MonoBehaviour
{
    public TodoListDisplay pickUpList;
    public DialogueManager orderNum;
    public DialogueTrigger dialogueTriggerScript;

    //public bool firstDialogue = false; //before picking up todo list
    public bool secondDialogue = false; //after picking up todo list
    public bool thirdDialogue = false; //after todo list is complete

    public GameObject firstDialogueTrigger;
    public GameObject secondDialogueTrigger;
    public GameObject thirdDialogueTrigger;

    public void Update()
    {
        if (dialogueTriggerScript.firstInteraction == true)
        {
            //Debug.Log("can now pick up todo list");
            CanNowPickupTodoList();
        }
        if (pickUpList.proceed == true)
        {
            //second dialogue
            Debug.Log("during todo list");
            DuringTodoList();


        }
        if (orderNum.order == 3)
        {
            //third dialogue
            Debug.Log("after completing todo list");
        }
    }

    void CanNowPickupTodoList()
    {
        pickUpList.proceed = true;
    }

    void DuringTodoList()
    {
        //set new convo
        //disable the dialogue on coworker
        //firstDialogueTrigger.SetActive(false);
        secondDialogueTrigger.SetActive(true);
    }

    void AfterTodoList()
    {
        //set final convo

    }
}
