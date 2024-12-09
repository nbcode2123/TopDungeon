using Script.SaveData.New_Folder;
using UnityEngine;

namespace Script.SaveData
{
    public class SaveGame : MonoBehaviour
    {
        public static MapData mapData;

        public static void init()
        {
            mapData = new MapData();
            // mapData.Save();
            mapData.Load();

        }
    }
}
