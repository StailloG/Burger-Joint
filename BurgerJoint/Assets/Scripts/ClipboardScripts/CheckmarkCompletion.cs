using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckmarkCompletion : MonoBehaviour
{
    public Image sweepCheckmark;
    public Image wipeCheckmark;
    public Image trashCheckmark;

    public ActionTask sweepAction;
    public ActionTask wipeAction;

    public TodoListDisplay list;

    [Header("Used in Other Scripts")]
    public bool tasksCompleted;

    void Start()
    {
        sweepCheckmark.enabled = false;
        wipeCheckmark.enabled = false;
        trashCheckmark.enabled = false;
        tasksCompleted = false;
    }

    void Update()
    {
        if (sweepAction.actionAreas.Count == 0)
        {
            FinishedSweeping();
        }
        if (wipeAction.actionAreas.Count == 0)
        {
            FinishedWiping();
        }

        allTasksCompleted();

    }

    private void FinishedSweeping()
    {
        if (list.displayList.enabled == true)
        {
            sweepCheckmark.enabled = true;
        }
        else
        {
            sweepCheckmark.enabled = false;
        }
       
    }

    private void FinishedWiping()
    {
        if (list.displayList.enabled == true)
        {
            wipeCheckmark.enabled = true;
        }
        else
        {
            wipeCheckmark.enabled = false;
        }
    }

    private void TrashTakenOut()
    {

    }

    public void allTasksCompleted()
    {
        if (wipeAction.actionAreas.Count == 0 && sweepAction.actionAreas.Count == 0)
        {
            tasksCompleted = true;
            Debug.Log("Speak to coworker now to finish the sweeping task!");
        }
    }

}
