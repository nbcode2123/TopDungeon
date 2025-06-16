using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DataLoader
{

    public static int DataConceptId()
    {
        string filePathConcept = Path.Combine(Application.persistentDataPath, "ConceptId.json");
        string json = File.ReadAllText(filePathConcept);
        ConceptID wrapper = JsonUtility.FromJson<ConceptID>(json);
        return wrapper.ID;

    }
    public static DataDungeon DataDungeon()
    {
        string filePathDungeon = Path.Combine(Application.persistentDataPath, "DungeonController.json");
        string json = File.ReadAllText(filePathDungeon);
        DataDungeon data = JsonUtility.FromJson<DataDungeon>(json);
        return data;

    }
    public static PlayerData DataCharacter()
    {
        string filePathCharacter = Path.Combine(Application.persistentDataPath, "Character.json");
        string json = File.ReadAllText(filePathCharacter);
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        return data;
    }
}
[System.Serializable]
public class ConceptID
{
    public int ID;
    public ConceptID(int id)
    {
        ID = id;
    }
}
[System.Serializable]

public class DataDungeon
{
    public int Level;
    public int Stage;
    public int EnemyCounter;
    public int GoldCounter;
    public int CoinCounter;
    public int EachStageInLevel = 1;
    public bool isBossStage = false;
    public int MaxLevel;
}
[System.Serializable]
public class PlayerData
{
    public string NameCharacter;
    public int CurrentHeath;
    public int CurrentAmmor;
    public int CurrentEnergy;
    public string Weapon1;
    public string Weapon2;
    public int Weapon1Id;
    public int Weapon2Id;
    public int MaxHeath;
    public int MaxAmmor;
    public int MaxEnergy;
}

