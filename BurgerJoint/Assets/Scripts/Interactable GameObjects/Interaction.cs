using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    [Header("Gameibjects")]
    public TextMeshProUGUI text;
    [Header("Testing")]
    [SerializeField] private bool isPlayerNear = false;
    [Header("To display ")]
    public bool interactable = false;

    void Start()
    {
        text.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear == true)
        {
            text.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("text is dipslayed");
                interactable = true;
            }
        }
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
        text.gameObject.SetActive(false);
    }
}
