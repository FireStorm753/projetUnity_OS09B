using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pages : MonoBehaviour
{
    private bool isReal;
    private int pageNumber;

    // Start is called before the first frame update
    void Start()
    {
        pageNumber = int.Parse(transform.parent.gameObject.name.Substring(7, 1));
        print(pageNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState() {
        Debug.Log("Ca marche");
       
        foreach(var page in MainMenu.RealPageList)
            Debug.Log(page);
        Debug.Log("Current page: "+pageNumber);
        if (MainMenu.RealPageList.Contains(pageNumber)) { 
            //compteur+1
            print("+1");
            PlayerMovement.counter++;
            
            Teacher.chasing = true;
        }
        Destroy(transform.parent.gameObject);
            
    }
}
