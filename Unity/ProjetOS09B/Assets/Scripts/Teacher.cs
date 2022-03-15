using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Teacher : MonoBehaviour
{
    public GameObject player;
    public GameObject[] waypoints;
    private int wayPointIndex;
    private UnityEngine.AI.NavMeshAgent agent;
    [SerializeField] public static bool chasing;
    [SerializeField] public static bool punch;
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
        wayPointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rayDirection = player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit, 3.0f))
        {
            if (hit.transform == player.transform && Vector3.Angle(rayDirection, transform.forward) < 60)
            {
                print("Player seen");
                chasing = true;
            }
            // else if (playerMovement.isMoving && playerMovement.isCrouching && rayDirection.magnitude < 1.0f) {
            //     print("Player crouched heard");
            // }
            else if (playerMovement.isMoving && rayDirection.magnitude < 3.0f)
            {
                print("Player heard");
                //agent.SetDestination(player.transform.position);
                chasing = true;
            }
        }

        if (chasing)
        {
            agent.SetDestination(player.transform.position);
            ani.SetBool("Run", true);
            ani.SetBool("Walk", false);
            GetComponent<NavMeshAgent>().speed = 2;
            punch = false;
        }
        else
        {
            punch = false;
            ani.SetBool("Run", false);
            ani.SetBool("Walk", true);
            GetComponent<NavMeshAgent>().speed = 1;
            Patrolling();
            

        }
    }

    void Patrolling()
    {
        float distance = Vector3.Distance(transform.position, waypoints[wayPointIndex].transform.position);
        if (distance < 1f)
        {
            if (wayPointIndex + 1 >= waypoints.Length)
                wayPointIndex = 0;
            else
                wayPointIndex++;
        }
        agent.SetDestination(waypoints[wayPointIndex].transform.position);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            chasing = false;
            punch = true;
            ani.SetBool("Run", false);
            ani.SetTrigger("TrCatch");
            numberOfHit++;
            if (numberOfHit >= 5)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("GameOver");

            }

        }
    }
}
