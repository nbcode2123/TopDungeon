using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
