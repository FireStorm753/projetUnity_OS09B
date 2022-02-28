using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState() {
        if (isOpen) {
            //play
            isOpen = false;
            print("fermer");
        }
        else {
            //play
            isOpen = true;
            print("ouvrir");
        }
            
    }
}
