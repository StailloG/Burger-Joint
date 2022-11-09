using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarInteraction : MonoBehaviour
{
    //variables
    public TextMeshProUGUI textDisplay;
    public bool showText = false;

    void Start()
    {
        textDisplay.gameObject.SetActive(false);
    }

    void Update()
    {
        if (showText == true && Input.GetKeyDown(KeyCode.Space))
        {
            textDisplay.gameObject.SetActive(true);
        }
    }

    /*
     * If player collides with the car
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            showText = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        showText = false;
        StartCoroutine(TextFewSec());
    }

    /*
     * Give the text a couple of seconds before disappearing -
     * incase player walks away from the car.
     */
    public IEnumerator TextFewSec()
    {
        yield return new WaitForSeconds(0.5f);
        textDisplay.gameObject.SetActive(false);
    }
}
