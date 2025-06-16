using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class MapDataSaver : MonoBehaviour
{
    // [SerializeField] public List<Vector2Int> FloorPosition;
    // [SerializeField] public List<Vector2Int> WallPosition;
    // [SerializeField] public List<Room> ListRoom;
    [SerializeField] public int ConceptId;
    [SerializeField] public List<Vector2Int> ColliderDirection;

    private void Start()
    {
        ObserverManager.AddListener("Save Game", CreateData);

    }
    public void CreateData()
    {

        ConceptId = DungeonConcept.Instance.CurrentTileMapAsset.ConceptId;
        ConceptID _id = new ConceptID(ConceptId);

        string filePathConcept = Path.Combine(Application.persistentDataPath, "ConceptId.json");


        DataSaver.SaveToJson(_id, filePathConcept);

        ColliderDirection = new List<Vector2Int>(MapProcessor.Instance.ColliderDirection);
        string filePathDirection = Path.Combine(Application.persistentDataPath, "Direction.json");
        DataSaver.SaveListToJson(ColliderDirection, filePathDirection);




    }



}

// [Serializable]
// public class Room
// {
//     [SerializeField]
//     public int RoomIndex;
//     [SerializeField]
//     public List<Vector2Int> FloorPos;
//     [SerializeField]
//     public List<Vector2Int> WallPos;
//     public Room(int index, List<Vector2Int> floorPos, List<Vector2Int> wallPos)
//     {
//         RoomIndex = index;
//         FloorPos = floorPos;
//         WallPos = wallPos;
//     }
// }
// [Serializable]
// public class MapData
// {
//     [SerializeField]

//     public List<Vector2Int> Floor;
//     [SerializeField]

//     public List<Vector2Int> Wall;
//     public MapData(List<Vector2Int> floor, List<Vector2Int> wall)
//     {
//         Floor = floor;
//         Wall = wall;

//     }
// }
