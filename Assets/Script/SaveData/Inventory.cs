using Script.SaveData.New_Folder;

namespace Script.SaveData
{
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
}
