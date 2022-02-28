using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;
    [SerializeField] MouseMovement mouse;

    PlayerControls controls;
    PlayerControls.PlayerActions groundMovement;

    Vector2 horizontalInput;
    Vector2 mouseInput;
    bool interact = false;

    Coroutine fireCoroutine;

    private void Awake ()
    {
        controls = new PlayerControls();
        groundMovement = controls.Player;

        // groundMovement.[action].performed += context => do something
        groundMovement.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.Look.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();
        //groundMovement.Interact.started += ctx => interact = true;
        groundMovement.Interact.performed += ctx => interact = true;
        groundMovement.Interact.canceled += ctx => interact = false;
        
        // groundMovement.Interact.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();

    }

    private void Update ()
    {
        movement.ReceiveInput(horizontalInput);
        mouse.ReceiveInput(mouseInput);
        
        
    }

    public void OnInteract (InputAction.CallbackContext context)
    {
        if (context.started)
            mouse.Interact(true);
        else if (context.performed)
            mouse.Interact(false);
    }

    private void OnEnable ()
    {
        controls.Enable();
    }

    private void OnDestroy ()
    {
        controls.Disable();
    }
}
