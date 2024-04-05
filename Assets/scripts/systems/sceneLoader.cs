using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public void game()
    {
        SceneManager.LoadScene("mainGame");
    }

    public void menu()
    {
        SceneManager.LoadScene("menu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu();
        }
    }

    public void info()
    {
        SceneManager.LoadScene("gameInfo");
    }
    public void info1()
    {
        SceneManager.LoadScene("gameInfo 1");
    }
    public void info2()
    {
        SceneManager.LoadScene("gameInfo 2");
    }
    public void info3()
    {
        SceneManager.LoadScene("gameInfo 3");
    }
    public void info4()
    {
        SceneManager.LoadScene("gameInfo 4");
    }
}
