using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    [SerializeField] private bool isPlayerNearFryer;
    [SerializeField] private bool isPlayerNearSodaMachine;

    public float x, y, z;

    public GameObject prefab;

    void Update()
    {
        if (isPlayerNearFryer == true && Input.GetKeyDown(KeyCode.Space) || isPlayerNearSodaMachine == true && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnPrefab());
            Debug.Log("Pressed space");
        }
    }

    /*
     * buffer inbetween foods.
     * create a completion bar??
     */
    IEnumerator SpawnPrefab()
    {
        yield return new WaitForSeconds(4f);

        SpawnPosition(x, y, z);
    }

    /*
     * input pos & prefab for ingredients
     * based on which appliance player is near
     */
    private void SpawnPosition(float x, float y, float z)
    {
        var pos = new Vector3(x, y, z);
        Instantiate(prefab, pos, Quaternion.identity);
    }

    //informs if player is near fryer or soda machine
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            if (this.gameObject.CompareTag("Fryer"))
            {
                isPlayerNearFryer = true;
            }

            if (this.gameObject.CompareTag("SodaMachine"))
            {
                isPlayerNearSodaMachine = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            isPlayerNearFryer = false;
            isPlayerNearSodaMachine = false;
        }
    }
}
