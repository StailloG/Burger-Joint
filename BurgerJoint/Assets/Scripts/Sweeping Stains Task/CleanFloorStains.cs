using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanFloorStains : MonoBehaviour
{
    private HandState handState;

    // Start is called before the first frame update
    void Start()
    {
        handState = GetComponentInParent<HandState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(handState.CurrentHandState == PickupType.BROOM)
        {
            //able to sweep stains if player is near stain
        }
    }
}
