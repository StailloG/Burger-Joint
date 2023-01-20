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

    // Start is called before the first frame update
    void Start()
    {
        
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
            
        }
    }

    public void TryDrop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.parent = null; //drop object
            //hide all outlines
            actionTask.HideAllOutLines();
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

public enum PickupType
{
    NONE,
    BROOM, 
    CLOTH
}