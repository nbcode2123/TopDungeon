using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class DungeonData : MonoBehaviour
{
    public int Level;
    public int Stage;
    public int EnemyCounter;
    public int GoldCounter;
    public int CoinCounter;
    public int EachStageInLevel = 1;
    public bool isBossStage = false;
    public int MaxLevel;


    // Start is called before the first frame update
    void Start()
    {
        ObserverManager.AddListener("Save Game", SaveDungeonData);


    }
    void OnDestroy()
    {
        ObserverManager.RemoveListener("Save Game", SaveDungeonData);
    }
    private void OnDisable()
    {
        ObserverManager.RemoveListener("Save Game", SaveDungeonData);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SaveDungeonData()
    {
        DungeonData dungeonData = new DungeonData
        {
            Level = DungeonController.Instance.Level,
            Stage = DungeonController.Instance.Stage,
            EnemyCounter = DungeonController.Instance.EnemyCounter,
            GoldCounter = DungeonController.Instance.GoldCounter,
            CoinCounter = DungeonController.Instance.CoinCounter,
            EachStageInLevel = DungeonController.Instance.EachStageInLevel,
            isBossStage = DungeonController.Instance.isBossStage,
            MaxLevel = DungeonController.Instance.MaxLevel

        };
        string filePath = Path.Combine(Application.persistentDataPath, "DungeonController.json");
        DataSaver.SaveToJson(dungeonData, filePath);


    }
}
