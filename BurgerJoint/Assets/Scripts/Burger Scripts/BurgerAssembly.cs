using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerAssembly : MonoBehaviour
{
    //variables
    [Header("Gameobjects")]
    private bool canPickUp = false;
    public GameObject playerHand;
    public GameObject ingredient;


    /*
     * Pick up & Drop item.
     */
    void Update()
    {
        if (canPickUp == true && Input.GetKeyDown(KeyCode.Space))
        {
            AttachToParent();
        }
        if (canPickUp == false && Input.GetKeyDown(KeyCode.E))
        {
            DetachFromParent();
        }
    }

    /*
     * If player collides with ingredients
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            canPickUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canPickUp = false;
    }

    /*
     * Player is the parent & ingredients are the child.
     */
    public void AttachToParent()
    {
        //burger is now child of player's hand
        ingredient.transform.parent = playerHand.transform;

        //set the pos of burger in front of player at all times
        transform.localPosition = new Vector3(0.4001f, -1.899f, -0.999f);

        canPickUp = false;
    }

    public void DetachFromParent()
    {
        transform.parent = null;
        
    }
}
