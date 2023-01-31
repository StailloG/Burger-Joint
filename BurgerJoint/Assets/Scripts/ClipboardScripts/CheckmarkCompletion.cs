using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckmarkCompletion : MonoBehaviour
{
    public Image sweepCheckmark;
    public Image wipeCheckmark;
    public Image trashCheckmark;

    public ActionTask actionTask;

    void Start()
    {
        sweepCheckmark.enabled = false;
        wipeCheckmark.enabled = false;
        trashCheckmark.enabled = false;
    }

    void Update()
    {
        if (actionTask.actionAreas.Count == 0)
        {
            FinishedSweeping();
        }
        
    }

    private void FinishedSweeping()
    {
        Debug.Log("List is empty");
    }

    private void FinishedWiping()
    {

    }

    private void TrashTakenOut()
    {

    }
}
