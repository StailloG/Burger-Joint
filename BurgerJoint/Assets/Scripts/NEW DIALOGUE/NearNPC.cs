using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearNPC : MonoBehaviour
{
    public bool playerNear = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            playerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            playerNear = false;
        }
    }
}
