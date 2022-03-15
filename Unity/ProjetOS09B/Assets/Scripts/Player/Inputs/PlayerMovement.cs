using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;
    Vector2 horizontalInput;

    [SerializeField] float gravity = -30f; // -9.81
    Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;
    public bool isMoving;
    public bool isCrouching;
    public static int counter = 0;

    private void Update ()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);
        if (isGrounded) {
            verticalVelocity.y = 0;
        }

        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        controller.Move(horizontalVelocity * Time.deltaTime);
        if (horizontalVelocity != Vector3.zero)
            isMoving = true;
        else
            isMoving = false;

        verticalVelocity.y += gravity * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }

    public void ReceiveInput (Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }
}

    // private CharacterController controller;

    // public bool isMoving = false;
    // public bool isSprinting = false;
    // public bool isCrouching = false;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     controller = gameObject.AddComponent<CharacterController>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    //     if (Input.GetKeyDown(KeyCode.LeftControl))
    //     {
    //         isCrouching = true;
    //     }
    //     if (Input.GetKeyUp(KeyCode.LeftControl))
    //     {
    //         isCrouching = false;
    //     }
    // }