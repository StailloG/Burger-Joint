using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private GameObject player;
    public GameObject taskItem; //drag gameobject that has this script

    [Header("Testing")]
    [SerializeField] private bool isPlayerNear = false;

    [Header("Used in Other Scripts")]
    public bool hasBroom = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
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

            //if item is a broom
            if (gameObject.CompareTag("Broom"))
            {
                hasBroom = true;
            }
        }
    }

    public void Drop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.parent = null; //drop object
            hasBroom = false;
        }
    }
}
