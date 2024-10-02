using System;

using System.IO;
using System.Runtime.Serialization;
using UnityEngine;
[Serializable]
public class DataTest
{
    [SerializeField]
    private int _Counter;
    [IgnoreDataMember]
    public int Counter
    {
        get => _Counter;
        set
        {
            _Counter = value;
            Save();
        }
    }
    // Start is called before the first frame update
    public void Save()
    {
        string json = JsonUtility.ToJson(this);
        File.WriteAllText(Application.persistentDataPath + "/Gamedata.game", json);
    }
    public void Load()
    {
        string filepath = Path.Combine(Application.persistentDataPath, "/Gamedata.game");
        if (File.Exists(filepath))
        {
            string json = File.ReadAllText(filepath);
            var data = JsonUtility.FromJson<DataTest>(json);

            Counter = data.Counter;

        }
    }
}
