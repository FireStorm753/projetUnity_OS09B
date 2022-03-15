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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState() {
        print(pageNumber);
        foreach (int x in MainMenu.RealPageList)
            print(x);
        if (MainMenu.RealPageList.Contains(pageNumber)) { 
            //compteur+1
            print("+1");
            PlayerMovement.counter++;
            
            Teacher.chasing = true;
        }
        Destroy(transform.parent.gameObject);
            
    }
}
