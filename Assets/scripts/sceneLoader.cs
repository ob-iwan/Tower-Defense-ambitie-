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
}
