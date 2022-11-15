using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerAssembly : MonoBehaviour
{
    /* Variables */
    [Header("Trigger Check")]
    private bool canPickUp = false;
    public int spacePressedAllowed = 0;

    [Header("Gameobjects")]
    public GameObject playerHand;
    public GameObject ingredient;

    [Header("Components")]
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /* Pick up & drop item */
    void Update()
    {
        if (canPickUp == true && Input.GetKey(KeyCode.Space) && spacePressedAllowed == 0)
        {
            AttachToParent();
            spacePressedAllowed = 1;
            Debug.Log("Picked up an ingredient.");
        }
        if (canPickUp == false && Input.GetKey(KeyCode.E) && spacePressedAllowed == 1)
        {
            DetachFromParent();
            spacePressedAllowed = 0;
            Debug.Log("Dropped an ingredient.");
        }
    }

    /* If player's hand collides with item */
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

    /* Player is the parent & item is the child */
    public void AttachToParent()
    {
        //burger is now child of player's hand
        ingredient.transform.parent = playerHand.transform;

        //gravity doesn't take place in player's hand
        rb.constraints = RigidbodyConstraints.FreezePosition;
        
        canPickUp = false;
    }

    /* Drop item */
    public void DetachFromParent()
    {
        transform.parent = null;

        rb.constraints = RigidbodyConstraints.None;
    }
}
