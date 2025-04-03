using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public static DungeonController Instance { get; private set; }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {

            Destroy(gameObject);

        }
        else
        {
            Instance = this;
        }
    }
    public int Level;
    public int Stage;
    public int CurrentRoom;
    public int NumberEnemyScount;
    public int Gold;
    public int Coin;
    public void InitializeDungeonValue()
    {
        Level = 1;
        Stage = 1;
        CurrentRoom = 0;
        Gold = 0;
        Coin = 0;
    }
    void Start()
    {
        ObserverManager.AddListener("EnemyDie", CountEnemy);
    }
    public void CountEnemy()
    {
        NumberEnemyScount++;
    }

}
