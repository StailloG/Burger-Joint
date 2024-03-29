using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * This script is used for when the player is getting the ingredients from the office
 * for the 'Refill Food From Pantry' task.
 * 
 * Uses a raycast 10f from the player.
 * Once the raycast hits a'BurgerIngredient' item, the raycast will turn green; red if not.
 * 
 * The IdentifyIngredient() method identifies which ingredient the raycast is hitting.
 *  This is so that when the player presses 'Spacebar', that ingredient is then instantiated
 *  by the PickUp() method.
 * 
 * Attach this script to Camera.
 */
public class Raycast : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] private float distance = 10f;
    [SerializeField] private bool holdingItem = false;
    private GameObject player;
    public GameObject ingredients;
    public GameObject hand;
    public TextMeshProUGUI raycastDot;

    public GameObject prefab;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        RaycastHit();

        if (holdingItem == true)
        {
            Drop();
        }
    }

    /*
     * Displays a ray up to 10f away from player's camera.
     * Displays green if ray hits a BurgerIngredient (LayerMask) & red if not.
     * 
     * Used to identify an ingredient for the player to pick up from crate.
     */
    private void RaycastHit()
    {
        if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out RaycastHit hitinfo, distance, layerMask))
        {
            raycastDot.color = Color.red;
            // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.green); //shows the raycast line

            //if player's raycast hits the ingredient crate
            IngredientCrate(hitinfo, "Ingredient");
        }
        else
        {
            raycastDot.color = Color.white;
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distance,  Color.red);
        }
    }

    /*
     * Identifies the item the raycast is hitting.
     * 
     * If player presses 'spacebar', uses the PickUp() method to pick up the ingredient.
     */
    private void IngredientCrate(RaycastHit ray, string name)
    {
        if (ray.collider.CompareTag(name))
        {
            //pickup object
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpawnIngredients(ray);
            }
        }
    }

    /*
     * Instantiates & childs the ingredient toppings to the parent.
     * 
     * Vector3 of player pos & pos of raycast makes the toppings spawn in front of player.
     */
    private void SpawnIngredients(RaycastHit ray)
    {
        var playerForward = player.transform.forward;
        var pos = ray.point + playerForward * 1;

        prefab = Instantiate(ingredients, pos, Quaternion.identity);
        prefab.transform.parent = hand.transform; //ojbect is child of player
    }

    private void Drop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            prefab.transform.parent = null;
        }
    }
}
