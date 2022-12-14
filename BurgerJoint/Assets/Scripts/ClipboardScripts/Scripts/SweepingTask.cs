using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Whenever player picks up the broom, areas placed inside the restaurant will start to glow.
 * The glowing areas indicate where the player will have to sweep.
 * Once the player sweeps the area by pressing spacebar, the glowing area will disappear.
 * 
 * Once all glowing areas disappear, the player has completed the sweeping task.
 * 
 * Place this script on the glowing areas gameOjbects.
 */

public class SweepingTask : MonoBehaviour
{
    [Header("Testing")]
    [SerializeField] private bool isPlayerNear = false;

    [Header("Activate Sweep Task")]
    PickUpObject hasItemScript;
    public GameObject glowArea;

    void Start()
    {
        hasItemScript = FindObjectOfType<PickUpObject>();

        GetComponent<MeshRenderer>().enabled = false;
    }

    void Update()
    {
        ActivateGlow();

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

    //deletes the area where player has swept
    private void Sweep()
    {
        Destroy(glowArea);
    }

    /* if player is holding the broom, the glowing areas will active.
     * if not, the glowing areas will disappear.
     */
    private void ActivateGlow()
    {
        if (hasItemScript.hasBroom == true)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

}
