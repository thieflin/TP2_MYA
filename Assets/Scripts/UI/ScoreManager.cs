using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour, IPublisher
{
    private int _score;
    [SerializeField] private int _scoreToBeat; //Score para llamar a la otra wave
    [SerializeField] private int _scoreMultiplier;

    //Opcion 1 Vade la mano de la opcion 3 pero bueno, sigo teniendo ese problema
    public List<ISubscriber> _subscribers = new List<ISubscriber>();

    //Opcion 2 mediante una clase intermediaria
    [SerializeField] private Observer _obs;

    [SerializeField] private Text scoreText = null;

    public void Start()
    {
        EventManager.Instance.Subscribe("OnDestroyingAsteroid", OnEnemyDestruction);
    }

    public void OnEnemyDestruction(params object[] parameters)
    {
        _score += (int) parameters[0];
        scoreText.text = _score.ToString();
        if(_score > _scoreToBeat)
        {
            //Opcion A
            NotifySubscribers("NewWave");

            //Opcion B
            _obs.NotifySubscribers("NewWave");


            _scoreToBeat *= _scoreMultiplier;
        }



    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            NotifySubscribers("NewWave");


            _obs.NotifySubscribers("NewWave");
        }
    }

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void NotifySubscribers(string id)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.OnNotify(id);
        }
    }
}
