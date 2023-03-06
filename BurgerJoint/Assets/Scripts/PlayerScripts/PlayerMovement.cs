using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script handles movement and interaction logic 
/// </summary>
public class PlayerMovement : MonoBehaviour, IKitchenObjectParent
{

    public static PlayerMovement Instance { get; private set; }
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;

    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
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
    private BaseCounter selectedCounter;
    private KitchenObject kitchenObject;
    [SerializeField] private Transform kitchenObjectHoldPoint;

    void Awake()
    {
        Instance = this;
        charController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        inputManager.OnInteractAction += InputManager_OnInteractAction;
        inputManager.OnInteractAlternateAction += InputManager_OnInteractAlternateAction;
    }

    private void InputManager_OnInteractAlternateAction(object sender, EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.InteractAlternate(this);
        }
    }

    private void InputManager_OnInteractAction(object sender, EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
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
            if (hitInfo.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                if (baseCounter != selectedCounter)
                {
                    selectedCounter = baseCounter;
                    SetSelectedCounter(baseCounter);

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


        //this temp var is so that moving sideways is slightly slower than moving forwards and back
        float sidewaySpeedBuffer = 0.667f;
        Vector3 velocity = transform.forward * (vInput * speed) + transform.right *( hInput* speed * sidewaySpeedBuffer);
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

    private void SetSelectedCounter(BaseCounter selectedCounter)
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

    public Transform GetKitchenObjectFollowTransform()
    {
        return kitchenObjectHoldPoint;
    }


    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }

}
