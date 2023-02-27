using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script handles movement and interaction logic 
/// </summary>
public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement Instance { get; private set; }
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;

    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public ClearCounter selectedCounter;
    }
    
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
    [SerializeField] private LayerMask counterLayerMask;
    [SerializeField] private InputManager inputManager;
    private ClearCounter selectedCounter;
    
    void Awake()
    {
        Instance = this;
        charController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        inputManager.OnInteractAction += InputManager_OnInteractAction;
    }

    private void InputManager_OnInteractAction(object sender, EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.Interact();
        }
        
      
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
        Ray CameraRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(CameraRay, out RaycastHit hitInfo, interactDistance, counterLayerMask))
        {
            //we are checking if the object that the raycast hits has a clearcounter script
            if (hitInfo.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                if (clearCounter != selectedCounter)
                {
                    selectedCounter = clearCounter;
                    SetSelectedCounter(clearCounter);

                }
            }
            else
            {
                selectedCounter = null;
                SetSelectedCounter(null);

            }
            
        }
        else
        {
            selectedCounter = null;
            SetSelectedCounter(null);
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

    private void SetSelectedCounter(ClearCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            selectedCounter = selectedCounter
        });
    }

    void OnDrawGizmosSelected()
    {
        
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Vector3 endpoint = transform.position + interactDistance *  transform.position - hand.transform.position;
            
             Gizmos.DrawLine(transform.position, endpoint);

    }
}
