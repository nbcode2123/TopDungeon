using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{

    public static MapData mapData;

    public static void init()
    {
        mapData = new MapData();
        // mapData.Save();
        mapData.Load();

    }

}
