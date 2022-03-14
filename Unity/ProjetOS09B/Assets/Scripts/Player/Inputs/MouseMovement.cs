using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{

    private Vector2 mouseMovement;
    private float mouseX, mouseY;
    [SerializeField] private float sensitivityX = 8f;
    [SerializeField] private float sensitivityY = 0.5f;

    [SerializeField] private Transform playerCamera;
    [SerializeField] private float xClamp = 85f;
    private float xRotation = 0f;
    
    private RaycastHit hit;
    private bool interact;

    private void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update ()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;

    }

    public void ReceiveInput (Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }

    public void OnInteract (InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 3.0f))
            {
                if (hit.transform.tag == "Interactable") {
                    print("Interacted with");   
                    
                    hit.transform.gameObject.SendMessage("ChangeState");
                }
            }
        }
    }
}
