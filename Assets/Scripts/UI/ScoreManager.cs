using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    [SerializeField] private Text scoreText = null;

    public void Start()
    {
        EventManager.Instance.Subscribe("OnDestroyingAsteroid", OnAsteroidDestruction);
    }

    public void OnAsteroidDestruction(params object[] parameters)
    {
        _score += (int) parameters[0];
        scoreText.text = _score.ToString();
    }
}
