using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float hInput;
    private float vInput;
    private CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
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
