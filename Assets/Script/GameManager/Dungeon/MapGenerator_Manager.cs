using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Tilemaps;

public class MapGenerator_Manager : MonoBehaviour
{


    public static MapGenerator_Manager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {

            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        ObserverManager.AddListener("Start Create Map", CreateMap);



    }



    // public RoomPrefab data;
    public List<RoomPrefab> ListRoomData;
    public int corridorLength, corridorcount;
    public PaintTilemap paintTilemap;
    public CorridorGenerator corridorGenerator;
    public RoomGeneration roomGeneration;
    public WallGenerator WallGenerator;
    HashSet<Vector2Int> corridors;
    public int corridorwidth = 5;
    public HashSet<Vector2Int> FloorPositions;
    public Tilemap ProtottypeRoom; // object đại diện cho roomcollider 
    public Tilemap PrototypeRoomWall; // object đại diện cho roomwallcollider
    public static HashSet<Vector2Int> FloorPositionsSave;
    public static HashSet<Vector2Int> CorridorPositionSave;
    public List<Vector2Int> roomPositionStart;

    public static MapData MapData;
    private string isNewMap = "New Map";
    public void GeneratorMap()
    {
        if (isNewMap == "New Map")
        {
            CreateMap();

        }
        else if (isNewMap == "Save Map")
        {
            LoadSaveMap();
        }



    }
    public void SaveTheMap()
    {
        MapData = new MapData();
        MapData.Save(FloorPositions, corridors);

    }

    public void LoadSaveMap()
    {
        MapData = new MapData();
        MapData.Load();
        paintTilemap.Clear();
        WallGenerator.CreateWall(MapData.floorPosition);
        PaintMap(MapData.floorPosition, MapData.corridorPosition);

    }
    public void ClearOldMapVariable()
    {
        roomPositionStart = new List<Vector2Int>();// danh sach vi tri bat dau cua 1 phong 
        corridors = new HashSet<Vector2Int>(); // danh sach vi tri hanh lang 
        FloorPositions = new HashSet<Vector2Int>(); // danh sach vi tri cac o san 
        paintTilemap.Clear(); // xoa cac tilemap da to 
    }
    public void GenerateMapPosition()
    {
        corridorGenerator.corridorcount = corridorcount; // Truyen so luong hanh lang cho Generator 
        corridorGenerator.corridorLength = corridorLength;// Truyen chieu dai  hanh lang cho Generator  
        corridors = corridorGenerator.CreateCorridor(roomPositionStart); // Generate Hanh lang kem theo tham chieu vi chi trung tam cua cac phong
        FloorPositions = roomGeneration.CreateRoom(roomPositionStart);// tao room tu vị trí các  ô trung tam cua phong 
        FloorPositions.UnionWith(corridors);
        WallGenerator.CreateWall(FloorPositions);
    }
    public void ClearVariableInRoomManager()
    {
        RoomManager.Instance.ListObjectRoom.Clear();// 
        RoomManager.Instance.RoomPosition.Clear();
        RoomManager.Instance.DicFloorPos.Clear();
        RoomManager.Instance.ListObjectRoomWall.Clear();
    }
    public void TransmitVariableToRoomManager()
    {
        List<Vector2Int> distinctList = roomPositionStart.Distinct().ToList();
        foreach (var item in distinctList) // lay ra vi tri trung cua cac phong de quan ly trong Room manager
        {
            RoomManager.Instance.RoomPosition.Add(item);

        }
        for (int i = 0; i < distinctList.Count; i++) // voi moi phong tao ra  object dai dien cho san cua phong do 
        {
            var _tempObjectFloorCollider = Instantiate(ProtottypeRoom);
            _tempObjectFloorCollider.name = "Room" + (i + 1);
            _tempObjectFloorCollider.GetComponent<RoomStats>().Index = i + 1;
            RoomManager.Instance.ListObjectRoom.Add(_tempObjectFloorCollider);
            var _tempListFloor = RoomManager.Instance.DicFloorPos[i];
            paintTilemap.PaintFloorPosition(_tempListFloor, _tempObjectFloorCollider);
        }
        for (int i = 0; i < distinctList.Count; i++) // voi moi phong tao ra object dai dien cho wall cua phong do 
        {

            var _tempObjectWallCollider = Instantiate(PrototypeRoomWall);
            _tempObjectWallCollider.name = "Wall" + (i + 1);
            _tempObjectWallCollider.GetComponent<RoomStats>().Index = i + 1;
            RoomManager.Instance.ListObjectRoomWall.Add(_tempObjectWallCollider);
            HashSet<Vector2Int> _tempListFloor = RoomManager.Instance.DicFloorPos[i];
            var _TempListWallPos = WallGenerator.CreateWall(_tempListFloor);
            paintTilemap.PaintFloorPosition(_TempListWallPos, _tempObjectWallCollider);




        }
    }

    public void CreateMap(params object[] data)
    {
        ClearVariableInRoomManager();
        ClearOldMapVariable();
        GenerateMapPosition();
        TransmitVariableToRoomManager();
        PaintMap(FloorPositions, corridors); // son tilemap cho cac phong va hanh lang
        RoomManager.Instance.CreateListRoom(); // tao danh sach cac phong trong RoomManager
    }
    public void PaintMap(HashSet<Vector2Int> FloorPositions, HashSet<Vector2Int> corridors)
    {
        paintTilemap.PaintCorridor(corridors);
        paintTilemap.PaintFloorPosition(FloorPositions);

        paintTilemap.wallPosition_top = WallGenerator.wallPosition_top;
        paintTilemap.wallPosition_bottom = WallGenerator.wallPosition_bottom;
        paintTilemap.wallPosition_left = WallGenerator.wallPosition_left;
        paintTilemap.wallPosition_right = WallGenerator.wallPosition_right;
        paintTilemap.PaintWall();
    }

    public void ClearTileMap()
    {
        paintTilemap.Clear();
    }
}
