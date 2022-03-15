using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent student;
    public GameObject Teleporter1To;
    public GameObject Teleporter2To;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Teleporter1"))
        {
            Player.transform.position = Teleporter1To.transform.position;
            student.GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(Player.transform.position);
        }

        if (collision.gameObject.CompareTag("Teleporter2"))
        {
            Player.transform.position = Teleporter2To.transform.position;
            student.GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(Player.transform.position);
        }
    }
}
