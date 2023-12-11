using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoworkerDialogueOrder : MonoBehaviour
{
    public TodoListDisplay pickUpList;
    public DialogueManager orderNum;

    void Update()
    {
        if (orderNum.order == 1)
        {
            //Debug.Log("can now pick up todo list");
            CanNowPickupTodoList();
        }
        if (orderNum.order == 2)
        {
            Debug.Log("during todo list");
        }
        if (orderNum.order == 3)
        {
            Debug.Log("after completing todo list");
        }

        //switch (orderNum.order)
        //{
        //    case 1:
        //        CanNowPickupTodoList();
        //        break;
        //    case 2:
        //        DuringTodoList();
        //        break;
        //    case 3:
        //        AfterTodoList();
        //        break;
        //}
    }

    void CanNowPickupTodoList()
    {
        pickUpList.proceed = true;
    }

    void DuringTodoList()
    {
        //set new convo
    }

    void AfterTodoList()
    {
        //set final convo
    }
}
