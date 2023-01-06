using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    private GameObject player;

    [Header("Testing")]
    [SerializeField] private bool isPlayerNear = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (isPlayerNear == true)
        {
            PickupBroom();
        }

        DropBroom();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerNear = false;
    }

    private void PickupBroom()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.parent = player.transform; //broom is child of player
        }
    }

    private void DropBroom()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.parent = null; //drop broom
        }
    }
}
