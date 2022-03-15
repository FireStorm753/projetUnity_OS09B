using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                SceneManager.LoadScene("Win");
            else
                Debug.Log("FIND MORE OF THEM " + PlayerMovement.counter + " ISN'T ENOUGH");
        }
        
    }

}
