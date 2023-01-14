using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingIngredients : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject prefab;
    private GameObject player;

    [Header("Testing")]
    [SerializeField] private bool isPlayerNear = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (isPlayerNear == true && Input.GetKeyDown(KeyCode.Space))
        {
            SpawnIngredient();
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

    private void SpawnIngredient()
    {
        Instantiate(prefab, player.transform.position, player.transform.rotation);
        prefab.transform.parent = player.transform; //ojbect is child of player
    }
}
