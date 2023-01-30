using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Events;



public class PickupGeneric : MonoBehaviour
{
    private GameObject player;
    public PickupType pickupType;

    [Header("Shown in inspector for debugging")]
    [SerializeField] private bool isPlayerNear = false;

    [SerializeField] private ActionTask actionTask;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isPlayerNear)
        {
            TryPickUp();
        }
        
        TryDrop();
    }

    public void TryPickUp()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.parent = player.transform; //ojbect is child of player
            //show all outlines, only for this type 
            actionTask.ShowAllOutlines();
            var i =player.GetComponent<HandState>();
            i.CurrentHandState = pickupType;
            
        }
    }

    public void TryDrop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.parent = null; //drop object
            //hide all outlines
           actionTask.HideAllOutLines(); 
            
            var i =player.GetComponent<HandState>();
            i.CurrentHandState = PickupType.NONE;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PlayerMovement>()) return;

        isPlayerNear = true;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            isPlayerNear = false;
        }
    }
}