using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepingTask : MonoBehaviour
{
    [Header("Testing")]
    [SerializeField] private bool isPlayerNear = false;

    [Header("Activate Sweep Task")]
    PickUpObject hasItemScript;

    void Start()
    {
        hasItemScript = FindObjectOfType<PickUpObject>();

        gameObject.SetActive(false); //off until player picks up broom
    }

    void Update()
    {
        ActivateSweepGlow();

        /* if player is inside sweeping area &
         * has broom &
         * presses spacebar,
         * player can sweep glowing areas
         */
        if (isPlayerNear == true && hasItemScript.hasBroom == true && Input.GetKeyDown(KeyCode.Space))
        {
            Sweep();
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

    //deletes the area where player has to sweep
    private void Sweep()
    {
        Destroy(gameObject);
    }

    public void ActivateSweepGlow()
    {
        if (hasItemScript.hasBroom == true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}