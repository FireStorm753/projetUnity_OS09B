using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teacher : MonoBehaviour
{
    public GameObject player;
    private UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] public static bool chasing;
    private RaycastHit hit;
    private Vector3 rayDirection;
    private PlayerMovement playerMovement;
    Animator ani;

    public int numberOfHit;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerMovement = player.GetComponent<PlayerMovement>();
        //Animation Controller of the current object
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rayDirection = player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit, 3.0f))
        {
            if (hit.transform == player.transform && Vector3.Angle(rayDirection, transform.forward) < 60) {
                print("Player seen");
                chasing = true;
            }
            // else if (playerMovement.isMoving && playerMovement.isCrouching && rayDirection.magnitude < 1.0f) {
            //     print("Player crouched heard");
            // }
            else if (playerMovement.isMoving && rayDirection.magnitude < 3.0f) {
                print("Player heard");
                //agent.SetDestination(player.transform.position);
                chasing = true;
            }
        }

        if (chasing)
        {
            agent.SetDestination(player.transform.position);
            ani.SetBool("Run", true);
        }
        else
        {
            agent.SetDestination(agent.transform.position);
            ani.SetBool("Run", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            chasing = false;
            ani.SetBool("Run", false);
            ani.SetTrigger("TrCatch");
            numberOfHit++;
            if (numberOfHit >= 2)
                SceneManager.LoadScene("Menu");
        }
    }
}
