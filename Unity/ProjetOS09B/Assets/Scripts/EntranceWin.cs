using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Lose HP
        // Play sound
        // Do whatever you like
        if (other.gameObject.name == "Player")
        {
            if (PlayerMovement.counter == 3)
                Debug.Log("You WON");
            else
                Debug.Log(other.gameObject.name+ "  FIND MORE OF THEM " + PlayerMovement.counter + " ISN't ENOUGH");
        }
    }
}
