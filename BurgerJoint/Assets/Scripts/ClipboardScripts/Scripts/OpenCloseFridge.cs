using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Opens the fridge when player presses spacebar.
 * Closes the fridge when the fridge is open & player presses spacebar.
 */

public class OpenCloseFridge : MonoBehaviour
{
    [Header("Testing")]
    [SerializeField] private bool isPlayerNear = false;
    [SerializeField] private bool fridgeIsOpen = false;

    [Header("Animation")]
    private Animator anim = null;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        /* if fridge is closed &
         * player is near fridge &
         * player presses spacebar,
         * fridge animation opens fridge.
         */
        if (fridgeIsOpen == false && isPlayerNear == true && Input.GetKeyDown(KeyCode.Space))
        {
            Open();
            fridgeIsOpen = true;
        }
        //close fridge when fridge is opened
        else if (fridgeIsOpen == true && isPlayerNear == true && Input.GetKeyDown(KeyCode.Space))
        {
            Close();
            fridgeIsOpen = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerNear = false;
    }

    private void Open()
    {
        anim.Play("OpenFridge", 0, 0.0f);
    }

    private void Close()
    {
        anim.Play("CloseFridge", 0, 0.0f);
    }
}
