using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private GameObject player;

    [Header("Testing")]
    [SerializeField] private bool isPlayerNear = false;

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

    private void Pickup()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.parent = player.transform; //ojbect is child of player
        }
    }

    private void Drop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.parent = null; //drop object
        }
    }
}
