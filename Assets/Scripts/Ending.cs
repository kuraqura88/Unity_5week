using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    
    public static bool isReset;

   

    public void ExitToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
