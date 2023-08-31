using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Intro of the game:
/// 1. player is next to the recently turned off car.
/// 2. player goes inside & talks to coworker.
/// 3. player is now able to do the to-do list.
/// 
/// Part 1:
/// 4. after todo list is done, player can now speak to the coworker again.
/// 
/// 5. coworker will teach player how to cook, then 3-4 customers start to walk in.
/// 6. after the 1st wave of customers is then coworker walks outside to take out trash.
/// 7. skinwalker takes coworker, so coworker doesn't come back.
/// 8. some player dialogue, then another wave of customers come through.
/// 9. 
/// 10. 
/// </summary>
public class SequenceOfEvents : MonoBehaviour
{
    [Header("Scripts")]
    public IntroCoworkerDialogue coDialogue;
    public TodoListDisplay todoList;
    public CheckmarkCompletion listComplete;

    [Header("Bool")]
    public bool proceedToTodoList;

    void Update()
    {
        From_Coworker_to_TodoList();
        From_List_to_Coworker();
    }

    /* If player finished speaking to coworker, then
     * player can now grab the to-do list.
     */
    public void From_Coworker_to_TodoList()
    {
        if (coDialogue.proceed == true)
        {
            todoList.proceed = true;
        }
    }

    /* Once player finished todo list, then
     * coworker walks out to take the trash
     */
    public void From_List_to_Coworker()
    {
        if (listComplete.tasksCompleted == true)
        {
            Debug.Log("Speak to coworker that you completed the tasks!");
            //TODO: create another script that controls when text pops up
        }
    }



}
