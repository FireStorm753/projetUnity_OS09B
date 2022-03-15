using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    public GameObject player;
    private UnityEngine.AI.NavMeshAgent student;
    Animator ani;
    private Vector3 rayDirection;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        student = GetComponent<UnityEngine.AI.NavMeshAgent>();
        ani = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = rotation;

        var lookPos = GameObject.FindWithTag("Player").transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
        bool isMoving = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().isMoving;
        if (isMoving == true) 
        {
            Debug.Log("Bouge");
            ani.SetBool("Run", true);
            student.SetDestination(player.transform.position);
        }
        else
        {
            Debug.Log("Bouge pas");
            ani.SetBool("Run", false);
            student.SetDestination(student.transform.position);
        }


        /*rayDirection = player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit, 30.0f))
        {
            if(rayDirection.magnitude > 1.0f)
            {
                ani.SetBool("Run", true);
                student.SetDestination(player.transform.position);
            }
           
        }*/
       

       
    }

   /* void OnTriggerEnter(Collider other)
    {
        // Lose HP
        // Play sound
        // Do whatever you like
        if (other.gameObject.name == "Player")
        {
            // It is object B
            Debug.Log("CA MARCHE");
            ani.SetBool("Run", false);
            student.SetDestination(student.transform.position);
            //ani.SetTrigger("TrCatch");
        }

    }*/
}
