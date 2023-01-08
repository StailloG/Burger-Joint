using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * NOT COMPLETE, NEEDS REFINEMENT
 */

public class TaskManager : MonoBehaviour
{
    [Header("Tasks Int Amount")]
    SweepingTask sweepTaskScript;

    [Header("Tasks Int Amount")]
    [SerializeField] private bool sweepComplete = false;
    [SerializeField] private int num = 0;

    void Start()
    {
        sweepTaskScript = FindObjectOfType<SweepingTask>();
    }

    void Update()
    {
        SweepTaskComplete();
    }

    private void SweepTaskComplete()
    {
        if (sweepTaskScript.sweepAmt == 4)
        {
            sweepComplete = true;
            Debug.Log("Sweeping task complete!");
        }
    }
}
