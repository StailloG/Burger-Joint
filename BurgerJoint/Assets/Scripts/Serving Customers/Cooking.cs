using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    [SerializeField] private bool isPlayerNear;
    public GameObject prefab;

    void Update()
    {
        if (isPlayerNear == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(SpawnPrefab());
            }
        }
    }

    //spawn prefab on table
    //private void UsingAppliance()
    //{
    //    var pos = new Vector3(6.784f, 1.871f, -26.867f);
    //    Instantiate(prefab, pos, Quaternion.identity);
    //}

    IEnumerator SpawnPrefab()
    {
        yield return new WaitForSeconds(5f);

        //if gameobject name is fries or soda, then add the method for it
    }

    private void FrenchFrySpawnPosition()
    {
        SpawnPosition(6.784f, 1.871f, -26.867f);
    }

    private void SodaSpawnPosition()
    {
        SpawnPosition(3.434169f, 3.185739f, 1.914402f);
    }

    private void SpawnPosition(float x, float y, float z)
    {
        var pos = new Vector3(x, y, z);
        Instantiate(prefab, pos, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            isPlayerNear = false;
        }
    }
}
