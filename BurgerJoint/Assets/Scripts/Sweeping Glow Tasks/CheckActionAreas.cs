using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The areas to sweep. Checks if the broom or cloth is inside its collider to remove itself from ActionTask
/// </summary>


public class CheckActionAreas : MonoBehaviour
{
    [SerializeField] private PickupType areaPickupType;

    [SerializeField] private bool isItemNear;

    //private ActionTask actionTask; <- commented out because using stains instead of outlines
    private StainsActionTask actionTask;

    private void Awake()
    {
        //actionTask = GetComponentInParent<ActionTask>();
        actionTask = GetComponentInParent<StainsActionTask>();
    }

    void Update()
    {
        if (isItemNear)
        {
            if(Input.GetKeyDown(KeyCode.Space))
                AttemptCleanAction();
        }
    }

    public void AttemptCleanAction()
    {
        GetComponent<StainsManager>().RemoveStains();
        actionTask.RemoveSelf(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            if (other.GetComponent<HandState>().CurrentHandState == areaPickupType)
            {
                isItemNear = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            isItemNear = false;
        }
    }
}
