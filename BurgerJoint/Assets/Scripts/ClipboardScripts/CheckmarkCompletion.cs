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

    void Start()
    {
        sweepCheckmark.enabled = false;
        wipeCheckmark.enabled = false;
        trashCheckmark.enabled = false;
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

}
