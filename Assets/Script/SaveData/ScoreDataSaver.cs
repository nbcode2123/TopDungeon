using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreDataSaver : MonoBehaviour
{
    public float totalTime;
    public int EnemyCount;
    public int StageCount;
    public int LevelCount;
    public Action OnTime;
    // Start is called before the first frame update
    void Start()
    {
        ObserverManager.AddListener<GameObject>("EnemyDie", CountEnemyDie);

        ObserverManager.AddListener("Stage Complete", CountStage);
        ObserverManager.AddListener("Level Complete", CountLevel);
        ObserverManager.AddListener("Game Complete", TimeUp);
        ObserverManager.AddListener("Game Complete", SaveScore);


        totalTime = 0;
        EnemyCount = 0;
        StageCount = 0;
        LevelCount = 0;

        OnTime += TimeCounting;



    }

    // Update is called once per frame
    void Update()
    {
        OnTime?.Invoke();

    }
    public void TimeCounting()
    {
        totalTime += Time.deltaTime;

    }
    public void TimeUp()
    {
        OnTime -= TimeCounting;

    }
    public void CountEnemyDie(GameObject Enemy)
    {
        EnemyCount++;
    }
    public void CountStage()
    {
        StageCount++;
    }
    public void CountLevel()
    {
        LevelCount++;
    }
    public void SaveScore()
    {

        ScoreData scoreData = new ScoreData
        {
            Time = totalTime,
            Enemy = EnemyCount,
            Stage = StageCount,
            Level = LevelCount
        };
        string filePath = Path.Combine(Application.persistentDataPath, "Score.json");
        if (FileChecker.CheckFile(filePath))
        {
            var _lastScore = DataLoader.DataScore();
            scoreData.Time += _lastScore.Time;
            scoreData.Enemy += _lastScore.Enemy;
            scoreData.Stage += _lastScore.Stage;
            scoreData.Level += _lastScore.Level;
            DataSaver.SaveToJson(scoreData, filePath);
        }
        else
        {
            DataSaver.SaveToJson(scoreData, filePath);

        }






    }
    private void OnDestroy()
    {
        ObserverManager.RemoveListener<GameObject>("EnemyDie", CountEnemyDie);
        ObserverManager.RemoveListener("Stage Complete", CountStage);
        ObserverManager.RemoveListener("Level Complete", CountLevel);
        ObserverManager.RemoveListener("Game Complete", TimeUp);
        ObserverManager.RemoveListener("Game Complete", SaveScore);
    }
    private void OnDisable()
    {
        ObserverManager.RemoveListener<GameObject>("EnemyDie", CountEnemyDie);
        ObserverManager.RemoveListener("Stage Complete", CountStage);
        ObserverManager.RemoveListener("Level Complete", CountLevel);
        ObserverManager.RemoveListener("Game Complete", TimeUp);
        ObserverManager.RemoveListener("Game Complete", SaveScore);
    }
}
