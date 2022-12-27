using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// The new pickup interaction script, now only the player needs this script and the objects just need to have the
/// specific layer tag and a rigid body. 
/// </summary>
public class ItemPickup : MonoBehaviour
{
    [SerializeField] private LayerMask PickupMask;//the layer that alll the pick up objects are set to

    [SerializeField] private Camera PlayerCamera;

    [SerializeField] private Transform PickUpTarget; //basically the "hand"

    [Space] [SerializeField] private float PickupRange;
    [SerializeField] private KeyCode InteractKey;
    [SerializeField][Range(12f, 144f)] private float MoveObjSpeed;
    private Rigidbody CurrentObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if you press interact key
        if (Input.GetKeyDown(InteractKey))
        {
            PickupSystem();
        }
    }


    private void FixedUpdate()
    {
        if (CurrentObj)
        {
            Vector3 DirectionToPoint = PickUpTarget.position - CurrentObj.position;
            float DistanceToPoint = DirectionToPoint.magnitude;
            
            //move the object according to your "hand"
            CurrentObj.velocity = DirectionToPoint * (MoveObjSpeed * DistanceToPoint);
        }
    }

    void PickupSystem()
    {
        //if the current object rigidbody is not null
        if (CurrentObj)
        {
            //make it be back to a normal object, ("drop" the object)
            CurrentObj.useGravity = true;
            CurrentObj = null;
            return;
        }
            
        //A ray that is that starts from the camera view 
        Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        //if the ray hits something within distance and has the pickup mask layer 
        if (Physics.Raycast(CameraRay, out RaycastHit hitInfo, PickupRange, PickupMask))
        {
            //"freeze" the object so we can move it in the FixedUpdate
            CurrentObj = hitInfo.rigidbody;
            CurrentObj.useGravity = false;
        }
    }
}
