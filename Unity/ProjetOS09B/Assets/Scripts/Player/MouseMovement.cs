using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = 0.5f;
    float mouseX, mouseY;

    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0f;

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
