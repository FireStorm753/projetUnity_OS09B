using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    [SerializeField] private bool interact;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3.0f))
        {
            if (hit.transform.tag == "Interactable" && interact == true) {
                print("Interacted with");   
                   
                //hit.transform.gameObject.SendMessage("ChangeState");
                hit.transform.GetComponent<Doors>().ChangeState();    
            }
        }
    }
}
