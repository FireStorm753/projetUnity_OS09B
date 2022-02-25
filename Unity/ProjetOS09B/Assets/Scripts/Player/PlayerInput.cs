using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
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
        groundMovement.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.Look.performed += ctx => mouseInput = ctx.ReadValue<Vector2>();

    }

    private void Update ()
    {
        movement.ReceiveInput(horizontalInput);
        mouse.ReceiveInput(mouseInput);
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
