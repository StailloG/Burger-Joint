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

            //identifies ingredient
            PickUp(hitinfo, "Tomato");
            
        }
        else
        {
            //Debug.Log("Nothing has been hit");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f,  Color.red);
        }
    }

    private void PickUp(RaycastHit ray, string name)
    {
        if (ray.collider.CompareTag(name))
        {
            Debug.Log("A " + name + " has been hit!");
            //GameObject itemGrabbed = ray.collider.gameObject;
        }
    }
}
