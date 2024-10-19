using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int _sceneNumber;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Load()
    {
        SceneManager.LoadScene(_sceneNumber);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
