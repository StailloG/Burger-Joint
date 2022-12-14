using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * If the player is near the task items (broom, cloth, & ingredients),
 * the player will be able to press spacebar to pick up those items.
 * 
 * Once the player picks up an item, that item will then be a child of the player.
 * When the player drops an item, that item will not be the child of the player anymore.
 * 
 * In the Pickup() method, when the player picks up an item,
 * there will be CompareTags to determine which item it is that the player picked up.
 * Depending on that item, that is when the task of that item will begin to glow in other scripts, such as:
 *      SweepingTask.cs
 *      ClothTask.cs (have yet to complete)
 *      IngredientsTask.cs (have yet to complete)
 *      
 * Place this script on the task items (broom, cloth, & ingredients).
 */

public class PickUpObject : MonoBehaviour
{
    private GameObject player;
    public GameObject taskItem; //drag gameobject that has this script

    [Header("Testing")]
    [SerializeField] private bool isPlayerNear = false;

    [Header("Using in Other Scripts")]
    public bool hasBroom = false;
    public bool hasCloth = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (isPlayerNear == true)
        {
            Pickup();
        }

        Drop();
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

    public void Pickup()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.parent = player.transform; //ojbect is child of player

            DetermineItem("Broom", ref hasBroom); //if item is a broom
            DetermineItem("Cloth", ref hasCloth); //if item is a cloth
        }
    }

    public void Drop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.parent = null; //drop object

            hasBroom = false;
            hasCloth = false;
        }
    }

    /*
     * Used in the Puckup() method to determine which item player has picked up.
     * Depending on the item, that is when the tasks will be activated.
     */
    public void DetermineItem(string tag, ref bool hasItem)
    {
        if (gameObject.CompareTag(tag))
        {
            hasItem = true;
        }
    }
}
