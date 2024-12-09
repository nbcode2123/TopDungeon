using System;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.SaveData
{
    [Serializable]
    public class DataTest
    {
        [FormerlySerializedAs("_Counter")] [SerializeField]
        private int counter;
        [IgnoreDataMember]
        public int Counter
        {
            get => counter;
            set
            {
                counter = value;
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
}
