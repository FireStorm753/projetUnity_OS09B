using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;
    [SerializeField] MouseMovement mouse;

    PlayerControls controls;
    PlayerControls.PlayerActions groundMovement;

    Vector2 horizontalInput;
    Vector2 mouseInput;

    Coroutine fireCoroutine;

    private void Awake ()
    {
        controls = new PlayerControls();
        groundMovement = controls.Player;

        // groundMovement.[action].performed += context => do something
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        groundMovement.Jump.performed += _ => movement.OnJumpPressed();

        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

    }

    private void Update ()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
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
