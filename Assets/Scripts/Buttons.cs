// This code is based on from Robert Smith's Github Video:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{


    public void LoadLevel0()
    {
        SceneManager.LoadScene("Level_0");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level_2");
    }


    public void LoadGameWon()
    {
        SceneManager.LoadScene("GameWon");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
