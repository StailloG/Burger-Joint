using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float hInput;
    private float vInput;
    private CharacterController charController;

    void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Start()
    {
       
    }

    void FixedUpdate()
    {
       HandleMovement();
    }

    private void HandleMovement()
    {
        //call horizontal & vertical inputs
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        //move horizontal & vertical
        Vector3 move = transform.right * hInput + transform.forward * vInput;

        //mouse movement
        charController.Move(move * speed * Time.deltaTime);
    }
}
