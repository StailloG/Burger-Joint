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
/// 4. coworker walks outside to take out trash.
/// 5. skinwalker takes coworker, so coworker doesn't come back.
/// 6. customers walk in.
/// 7. player serves customers.
/// 8. 
/// </summary>
public class SequenceOfEvents : MonoBehaviour
{
    [Header("Scripts")]
    public IntroCoworkerDialogue coDialogue;
    public TodoListDisplay todoList;

    [Header("Bool")]
    public bool proceedToTodoList;

    private void Update()
    {
        CoworkerToTodoList();
    }

    /* If player finished speaking to coworker, then
     * player can now grab the to-do list.
     */
    void CoworkerToTodoList()
    {
        if (coDialogue.proceed == true)
        {
            todoList.proceed = true;
        }
    }



}
