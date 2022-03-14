using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pages : MonoBehaviour
{
    private bool isReal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState() {
        if (isReal) {
            //compteur+1
            
        }
        Destroy(transform.parent.gameObject);
            
    }
}
