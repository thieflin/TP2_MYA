using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour, IScenes
{
    [SerializeField] private GameObject _mainMenu = null, _instructions = null;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Instructions()
    {
        _instructions.SetActive(true);
        _mainMenu.SetActive(false);
    }

    public void Back()
    {
        _mainMenu.SetActive(true);
        _instructions.SetActive(false);
    }
}
