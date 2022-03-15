using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentGoToG : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent student;
    float distanceFromCamera = 2f;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Vector3 centerPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, distanceFromCamera));
            student.GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(centerPos);
        }
    }
}
