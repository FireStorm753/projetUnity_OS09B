using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public GameObject prof;
    AudioSource audios;
    // Start is called before the first frame update
    void Start()
    {
        prof = GameObject.FindWithTag("Prof");
        audios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool chase = Teacher.chasing;
        if (chase && audios.isPlaying == false)
            audios.Play();
        else if (!chase && audios.isPlaying == true)
            audios.Stop();
    }
}