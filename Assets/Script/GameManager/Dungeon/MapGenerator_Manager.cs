using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

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
    List<Vector2Int> roomPositionStart;
    HashSet<Vector2Int> corridors;
    public HashSet<Vector2Int> FloorPositions;
    public static HashSet<Vector2Int> FloorPositionsSave;
    public static HashSet<Vector2Int> CorridorPositionSave;
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

    public void CreateMap()
    {
        List<Vector2Int> roomPositionStart = new List<Vector2Int>();// danh sach vi tri bat dau cua 1 phong 
        corridors = new HashSet<Vector2Int>();
        FloorPositions = new HashSet<Vector2Int>();
        paintTilemap.Clear();
        corridorGenerator.corridorcount = corridorcount;
        corridorGenerator.corridorLength = corridorLength;
        corridors = corridorGenerator.CreateCorridor(roomPositionStart);// tao ra corridor va tu do lay vi tri dau tien cua cac room
        FloorPositions = roomGeneration.CreateRoom(roomPositionStart);// tao room tu vị trí các  ô phòng
        FloorPositions.UnionWith(corridors);
        WallGenerator.CreateWall(FloorPositions);
        PaintMap(FloorPositions, corridors);
        RoomManager.Instance.RoomPosition = new List<Vector2Int>();
        List<Vector2Int> distinctList = roomPositionStart.Distinct().ToList(); // ;loại bỏ các giá trị trùng trong vị trí phòng trong trường hợp các phòng bị chồng lên nhau 
        foreach (var item in distinctList)
        {
            RoomManager.Instance.RoomPosition.Add(item);

        }
        RoomManager.Instance.ArrangeRoomPositon();
        RoomManager.Instance.CreateListRoom();



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
