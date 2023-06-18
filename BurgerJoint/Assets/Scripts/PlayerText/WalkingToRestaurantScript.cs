using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WalkingToRestaurantScript : MonoBehaviour
{
    //variables
    public TextMeshProUGUI textDisplay;
    public bool isPlayerCollide = false;

    void Start()
    {
        textDisplay.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPlayerCollide == true)
        {
            textDisplay.gameObject.SetActive(true);
        }
    }

    /*
     * If player collides with invisible collider
     * while walking towards the resetaurant.
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerCollide = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerCollide = false;
        }
    }

    /*
     * Give the text a couple of seconds before disappearing -
     * incase player walks away from the car.
     */
    public IEnumerator TextFewSec()
    {
        yield return new WaitForSeconds(2.0f);
        textDisplay.gameObject.SetActive(false);
        //Destroys collider so text does not appear again
        Destroy(gameObject);
    }
}
