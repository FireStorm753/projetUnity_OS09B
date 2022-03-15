using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceWin : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < 1f)
        {
            if (PlayerMovement.counter >= 3)
                Debug.Log("WIN WIN WIN");
            else
                Debug.Log("FIND MORE OF THEM " + PlayerMovement.counter + " ISN'T ENOUGH");
        }
        
    }

}
