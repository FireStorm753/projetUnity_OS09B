using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public GameObject player;
    private RaycastHit hit;
    private Vector3 rayDirection;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        rayDirection = player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit, 10.0f))
        {
            if (hit.transform == player.transform && Vector3.Angle(rayDirection, transform.forward) < 60) {
                print("Player seen");
            }
            // else if (playerMovement.isMoving && playerMovement.isCrouching && rayDirection.magnitude < 1.0f) {
            //     print("Player crouched heard");
            // }
            else if (playerMovement.isMoving && rayDirection.magnitude < 3.0f) {
                print("Player heard");
            }
        }    
    }
}
