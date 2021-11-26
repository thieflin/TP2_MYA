using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour, ISubscriber
{
    [SerializeField] List<GameObject> _waves = new List<GameObject>();
    private int _waveCounter;

    //Opcion A
    public IPublisher smint;

    //Opcion B
    public Observer obs;

    public void Start()
    {
        //Opcion A
        smint = FindObjectOfType<ScoreManager>();
        smint.Subscribe(this);

        //OpcionB
        obs.Subscribe(this);

        //Opcion C
        //smint = new ScoreManager(); El problema de esta es que hace una instancia nueva yh no me toma el valor del score logicamente

    }
    public void OnNotify(string eventID)
    {
        if(eventID == "NewWave")
        {
            _waves[_waveCounter].SetActive(true);
            _waveCounter++;
        }
    }
}
