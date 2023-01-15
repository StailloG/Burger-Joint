using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    void Update()
    {
        RaycastHit();
    }

    private void RaycastHit()
    {
        if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out RaycastHit hitinfo, 20f, layerMask))
        {
            //Debug.Log("Hit something");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.green);
        }
        else
        {
            //Debug.Log("Nothing has been hit");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f,  Color.red);
        }
    }
}
