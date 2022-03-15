using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject player;
    AudioSource audios;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        audios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isMoving = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().isMoving;
        if (isMoving && audios.isPlaying == false)
            audios.Play();
        else if (!isMoving && audios.isPlaying == true)
            audios.Stop();
    }
}
