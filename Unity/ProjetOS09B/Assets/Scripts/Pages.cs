using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pages : MonoBehaviour
{
    private bool isReal;
    private int pageNumber;

    public Text textElement;

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
        if (MainMenu.RealPageList.Contains(pageNumber)) { 
            PlayerMovement.counter++;
            print("+1");
            textElement.text = "Pages ramassés : "+PlayerMovement.counter+"/2";
            
            Teacher.chasing = true;
        }
        Destroy(transform.parent.gameObject);
            
    }
}
