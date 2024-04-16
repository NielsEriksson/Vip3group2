using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    //Inputs
    private PlayerInputActions playerInputActions;
    private InputAction moveInput;
    private InputAction jumpButton;
    private InputAction InteractionButton;

    //refrences
    PlayerMovement playerMovement; //ref to player movement to inform when jump etc has been pressed

    // Events
    [SerializeField] private UnityEvent onInteraction;


    //properties to be used outside of the class
    public Vector2 MoveDirection { get { return moveInput.ReadValue<Vector2>(); } }

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void OnEnable()
    {
        moveInput = playerInputActions.Player.Move;
        moveInput.Enable();

        jumpButton = playerInputActions.Player.Jump;
        jumpButton.Enable();
        jumpButton.performed += Jump;

        InteractionButton = playerInputActions.Player.Interaction;
        InteractionButton.Enable();
        InteractionButton.performed += Interaction;
    }

    private void OnDisable()
    {
        moveInput.Disable();

        jumpButton.Disable();
        jumpButton.performed -= Jump;

        InteractionButton.Disable();
        InteractionButton.performed -= Interaction;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        playerMovement.Jump();
    }

    private void Interaction(InputAction.CallbackContext context)
    {
        //Trigger interaction event
        onInteraction?.Invoke();
    }
}
