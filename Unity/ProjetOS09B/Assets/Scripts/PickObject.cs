using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Your_Name_Here");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void pickup()
    {
        //recupérer la variable globale du nombre de copies de l'utilisateur et l'incrémenter d'un
    }


    void OnMouseDown()
    {
        /*float minDist = 2;
        float dist = Vector3.Distance(other.position, player.transform.position);
        if (dist < minDist)
        {
            pickup();
        }*/
    }
}
