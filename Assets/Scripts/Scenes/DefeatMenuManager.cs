using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefeatMenuManager : MonoBehaviour, IScenes
{
    [SerializeField] private GameObject defeatMenu = null;
    void Start()
    {
        EventManager.Instance.Subscribe("OnDeath", Reload);
    }

    public void Reload(params object[] parameters)
    {
        defeatMenu.SetActive(true);
        Time.timeScale = 0f;
    }


    public void Play()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
