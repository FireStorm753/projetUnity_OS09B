using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    public GameObject player;
    private UnityEngine.AI.NavMeshAgent student;
    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        student = GetComponent<UnityEngine.AI.NavMeshAgent>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
