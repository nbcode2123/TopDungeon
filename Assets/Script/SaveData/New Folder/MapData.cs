using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


public class MapData : Data
{
    // Start is called before the first frame update
    public HashSet<Vector2Int> floorPosition;
    public HashSet<Vector2Int> corridorPosition;

    public void Save(HashSet<Vector2Int> floorPosition, HashSet<Vector2Int> corridorPosition)
    {


        // Chuyển đổi HashSet<Vector2Int> thành một mảng Vector2Int[]
        Vector2Int[] positionsArray = new Vector2Int[floorPosition.Count];
        Vector2Int[] corridorsArray = new Vector2Int[corridorPosition.Count];
        floorPosition.CopyTo(positionsArray);
        corridorPosition.CopyTo(corridorsArray);
        Vector2IntArrayWrapper wrapper = new Vector2IntArrayWrapper();
        wrapper.positions = positionsArray;
        wrapper.corridors = corridorsArray;
        // Chuyển đổi mảng thành dữ liệu JSON
        string json = JsonUtility.ToJson(wrapper);
        // Lưu dữ liệu xuống tệp
        File.WriteAllText(Application.persistentDataPath + "/FloorPositions.json", json);
    }
    public void Load()
    {
        string filePath = Application.persistentDataPath + "/FloorPositions.json";
        if (File.Exists(filePath))
        {
            // Đọc dữ liệu từ tệp
            string json = File.ReadAllText(filePath);

            // Chuyển đổi dữ liệu JSON thành mảng Vector2Int[]
            Vector2IntArrayWrapper wrapper = JsonUtility.FromJson<Vector2IntArrayWrapper>(json);
            floorPosition = new HashSet<Vector2Int>(wrapper.positions);
            corridorPosition = new HashSet<Vector2Int>(wrapper.corridors);

        }
        else
        {
            Debug.LogWarning("Floor positions file not found.");
        }



    }
    [Serializable]
    public class Vector2IntArrayWrapper
    {
        public Vector2Int[] positions;
        public Vector2Int[] corridors;
    }
}
