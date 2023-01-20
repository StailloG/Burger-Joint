using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The areas to sweep. checks if the broom or cloth is inside it to remove itself from ActionTask
/// </summary>
public class CheckAction : MonoBehaviour
{
    [SerializeField] private PickupType areaPickupType;

    [SerializeField] private bool isItemNear;

    private ActionTask actionTask;

    private void Awake()
    {
        actionTask = GetComponentInParent<ActionTask>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        GetComponent<OutlineManager>().HideOutline();
        actionTask.RemoveSelf(this);
        Debug.Log("trying to clean");
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<PlayerMovement>())
        {
            isItemNear = true;
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
