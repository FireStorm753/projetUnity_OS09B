using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    [SerializeField] private float sensitivityX = 8f;
    [SerializeField] private float sensitivityY = 0.5f;
    public float mouseX, mouseY;

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

        // if (Physics.Raycast(transform.position, transform.forward, out hit, 3.0f))
        // {
        //     if (hit.transform.tag == "Interactable") {
        //         print("Interactable");
        //         if (interact == true) 
        //             print("Interacted with");
        //     }
        // }

    }

    public void ReceiveInput (Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }

    public void Interact (bool interacting)
    {
        interact = interacting;
    }
    
    // private float mouseX;
    // private float mouseY;
    // private float mouseSensitivity = 100.0f;

    // public Transform player;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    //     mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

    //     player.Rotate(Vector3.up * mouseX);
    // }
}
