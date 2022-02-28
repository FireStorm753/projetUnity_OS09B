using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    private bool interact;
    private RaycastHit hit;

    public void OnInteract (InputAction.CallbackContext context)
    {
        if (context.started)
            interact = true;
        else if (context.performed)
            interact = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        print("a");
    }

    // Update is called once per frame
    void Update()
    {
        print("a");
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3.0f))
        {
            if (hit.transform.tag == "Interactable") {
                print("Interactable");
                if (interact == true) 
                    print("Interacted with");
            }
        }
    }
}
