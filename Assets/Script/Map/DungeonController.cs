using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using TMPro;
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
    public int EnemyCounter;
    public int GoldCounter;
    public int CoinCounter;
    public int EachStageInLevel = 1;
    public bool isBossStage = false;
    public int MaxLevel;

    public void InitializeDungeonValue()
    {
        Level = 1;
        Stage = 1;
        CurrentRoom = 0;
        GoldCounter = 0;
        CoinCounter = 0;
        EnemyCounter = 0;
        isBossStage = false;
    }
    void Start()
    {
        ObserverManager.AddListener("EnemyDie", CountEnemyDie);
        ObserverManager.AddListener("Stage Complete", NewLevelUpdate);
    }
    public void CountEnemyDie()
    {
        EnemyCounter++;
    }
    private void OnDestroy()
    {
        ObserverManager.RemoveListener("EnemyDie", CountEnemyDie);
        ObserverManager.RemoveListener("Stage Complete", NewLevelUpdate);

    }
    private void OnDisable()
    {
        ObserverManager.RemoveListener("EnemyDie", CountEnemyDie);
        ObserverManager.RemoveListener("Stage Complete", NewLevelUpdate);

    }
    public void NewLevelUpdate()
    {
        if (Stage != EachStageInLevel || Level != MaxLevel)
        {
            if (Stage + 1 > EachStageInLevel)
            {
                Stage = 1;
                Level++;
                isBossStage = false;


            }
            else if (Stage + 1 <= EachStageInLevel)
            {
                Stage++;
                if (Stage == EachStageInLevel)
                {
                    isBossStage = true;

                }
            }
            GameManager.Instance.Player.transform.position = Vector3.zero;
            CurrentRoom = 0;
            TrashCan.Instance.ClearTrashCan();
            MapProcessor.Instance.StartMapProcess();
        }
        else if (Stage == EachStageInLevel && Level == MaxLevel)
        {
            ObserverManager.Notify("Game Complete");

        }



    }


}
