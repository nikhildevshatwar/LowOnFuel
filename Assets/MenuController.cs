using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject credits;
    private bool showcred;

    private void Start()
    {
        showcred = false;
    }


    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Credits()
    {
        if (showcred == false)
        {
            credits.SetActive(true);
            showcred = true;
            return;
        }
        if (showcred == true)
        {
            credits.SetActive(false);
            showcred = false;
            return;
        }

    }

    public void Quit()
    {
        Application.Quit();
    }
}
