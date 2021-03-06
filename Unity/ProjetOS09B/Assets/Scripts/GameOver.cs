using UnityEngine.SceneManagement;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class GameOver : MonoBehaviour
{
    public static List<int> RealPageList = new List<int>();
    
    public void RestartGame()
    {
        for (int i = 0; i < 3; i++)
        {
            int random = (int) UnityEngine.Random.Range(0, 10)+1;
            if (RealPageList.Contains(random))
                i--;
            else
                RealPageList.Add(random);
        }
        PlayerMovement.counter = 0;
        SceneManager.LoadScene("MainScene");
    }

    public void MenuGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
