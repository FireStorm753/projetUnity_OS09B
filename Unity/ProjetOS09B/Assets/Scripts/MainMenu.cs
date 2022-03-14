using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    public static List<int> RealPageList = new List<int>(); //int[] RealPageList;

    public void PlayGame()
    {
        for (int i = 0; i < 3; i++)
        {
            int random = (int) UnityEngine.Random.Range(0, 10)+1;
            if (RealPageList.Contains(random))
                i--;
            else
                RealPageList.Add(random);
        }
        SceneManager.LoadScene("LucScene");
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
