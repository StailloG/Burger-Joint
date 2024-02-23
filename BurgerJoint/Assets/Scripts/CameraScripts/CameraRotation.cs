using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// To move camera and player for an effective first-person controller.
/// </summary>
public class CameraRotation : MonoBehaviour
{
    public Transform playerBody; //transform camera with player body
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    public Vector3 target; //need to do something else
    public PlayerMovement playerMovement;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (playerMovement.playerIsInMovement == true)
        {
            CameraControl();
        }
        //if (playerMovement.playerIsInMovement == false)
        //{
        //    Face();
        //}
       
    }


    private void CameraControl()
    {
        //call input access
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //rotation is flipped
        xRotation -= mouseY;

        //clamp rotation to not be able to look too high up
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //rotate body with camera
        playerBody.Rotate(Vector3.up * mouseX);
    }

    //private void Face()
    //{
    //    this.transform.LookAt(target);
    //}
}
