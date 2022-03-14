using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //m_Source = GetComponent<AudioSource>;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Quit");
        //Application.Quit();

        SceneManager.LoadScene("Menu");
    }
}
