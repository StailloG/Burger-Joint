using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    [SerializeField] private float interactDistance = 2f;
    //this hand object is used to determine direction from middle of screen
    //this is because the camera is currenlt set at an angle 
    [SerializeField] private GameObject hand;
    private float hInput;
    private float vInput;
    private CharacterController charController;
    private const float Gravity = 9.81f;
    private float vSpeed;
    void Awake()
    {
        charController = GetComponent<CharacterController>();
    }


    void FixedUpdate()
    {
       HandleMovement();
       
    }

    private void Update()
    {
        HandleInteractions();
    }

    private void HandleInteractions()
    {
        Vector3 camDirection = transform.position - hand.transform.position;
        if (Physics.Raycast(transform.position, camDirection, out RaycastHit raycastHit, interactDistance))
        {
            Debug.Log(raycastHit.transform);
        }
        else
        {
          
        }
    }
    private void HandleMovement()
    {
        //call horizontal & vertical inputs
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        Vector3 velocity = transform.forward * (vInput * speed) + transform.right * hInput;
        if (charController.isGrounded)
            vSpeed = 0;

        vSpeed -= Gravity * Time.deltaTime;
        velocity.y = vSpeed; 

        //mouse movement
        charController.Move(velocity *  Time.deltaTime);
        
    }

    //Script to help other systems know when the player is moveing
    public bool IsMoving()
    {
        return charController.velocity != Vector3.zero;
    }
    
    
    void OnDrawGizmosSelected()
    {
        
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Vector3 endpoint = transform.position + interactDistance *  transform.position - hand.transform.position;
            
             Gizmos.DrawLine(transform.position, endpoint);

    }
}
