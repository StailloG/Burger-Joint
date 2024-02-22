using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsNPCActive : MonoBehaviour
{
    public GameObject npc;

    public GBStartWalking canWalkScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canWalkScript.GBCanNowWalkIn == true)
        {
            npc.SetActive(true);
        }
        if (canWalkScript.GBCanNowWalkIn == false)
        {
            npc.SetActive(false);
        }
    }
}
