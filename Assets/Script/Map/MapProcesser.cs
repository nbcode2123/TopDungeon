using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;


public class MapProcesser : MonoBehaviour
{
    public static MapProcesser Instance { get; private set; }
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public RoomGenerator roomGenerator;  // chua cac phuong thuc tao ra cac thanh phan cua 1 room bao gom floor, wall
    public TileMapProcesser tileMapProcesser;  // chua cac phuong thuc de paint tile map 
    public ColiderGenerator coliderGenerator; // chua cac phuong thuc ve hanh lang (colider)
    public WallProcesser wallProcesser;
    public EnviromentGenerator enviromentGenerator;
    [SerializeField] private int RoomSize = 35;
    public int RoomNumber = 5;
    public int SpacingBetweenEachRoom;
    public GameObject RoomObject;
    public List<Vector2Int> FloorPosition;
    public List<Vector2Int> ListRoomCenterPosition; // co the xoa 
    public List<GameObject> ListRoomObject;
    public TileMapAssetConcept tileMapAssetConcept;
    void OnEnable()
    {
        ObserverManager.AddListener("DungeonStart", MapGenerator);

    }
    void OnDisable()
    {
        ObserverManager.RemoveListener("DungeonStart", MapGenerator);

    }
    void OnDestroy()
    {
        ObserverManager.RemoveListener("DungeonStart", MapGenerator);


    }

    public void Start()
    {

    }
    // public override void InstallBindings()
    // {

    // }

    public void MapGenerator()
    {
        InitializeGeneration();
        DecideConcept();
        CreateRoomObjectPooling(); // rao ra pool cho object dai dien cho cac room
        CreateRoomAndColider();
        AddEnviromentToRoom();
        PaintTileMap(FloorPosition);
        ObserverManager.Notify("Map Generator Complete");
    }
    public void InitializeGeneration()
    {
        TileMapProcesser.Instance.ClearAllTileMap(); // clear tat ca cac tilemap 
        ListRoomCenterPosition.Clear(); // clear vi tri trung tam cua cac phong
        ListRoomObject.Clear(); // clear cac object dai dien cho room
        FloorPosition.Clear(); // clear danh sach vi tri floor 
        MapManager.Instance.TilemapAssetConcept = DungeonConcept.Instance.TilebaseCollector[0]; //! lay ra concept map, nho code lai 


    }

    public void CreateRoomObjectPooling()
    {
        ObjectPoolManager.Instance.CreatePoolForDuplicateObject(RoomObject);
        ObjectPoolManager.Instance.SpawnThePool(RoomObject.name, RoomNumber);
        ListRoomObject = ObjectPoolManager.Instance.ListObjectFromPool(RoomObject.name);
    }
    public List<Vector2Int> CreateColiderDirection()
    {
        coliderGenerator.ColiderDirectionGenerator(RoomNumber);
        return coliderGenerator.ColiderDirection;

    }
    public void CreateRoomAndColider()
    {
        var _coliderDirection = CreateColiderDirection();
        CreateRoom(_coliderDirection, Vector2Int.zero);
    }
    public void CreateRoom(List<Vector2Int> coliderDirection, Vector2Int startPostion)
    {
        var _currentPosition = startPostion;
        for (int i = 0; i < RoomNumber; i++)
        {
            ListRoomCenterPosition.Add(_currentPosition);
            var _floorPositionEachRoom = roomGenerator.FloorGenerator(_currentPosition, RoomSize);
            FloorPosition.AddRange(_floorPositionEachRoom);
            if (i != RoomNumber - 1)
            {
                _currentPosition = CreateColider(_currentPosition, coliderDirection[i]);
            }
            var _wallPositionEachRoom = wallProcesser.WallGenerator(_floorPositionEachRoom);
            CreateRoomObjectComponents(i, _wallPositionEachRoom, _floorPositionEachRoom);
        }
    }
    public Vector2Int CreateColider(Vector2Int startPostion, Vector2Int direction)
    {
        Vector2Int _currentPosition = startPostion;
        var _colider = coliderGenerator.WalkColider(_currentPosition, SpacingBetweenEachRoom + RoomSize, direction);
        FloorPosition.AddRange(_colider.WalkPosition);
        _currentPosition = _colider.EndPosition;
        while (ListRoomCenterPosition.Contains(_colider.EndPosition))
        {
            _colider = coliderGenerator.WalkColider(_currentPosition, SpacingBetweenEachRoom + RoomSize, direction);
            FloorPosition.AddRange(_colider.WalkPosition);
            _currentPosition = _colider.EndPosition;
        }
        return _currentPosition;

    }
    public void DecideConcept()
    {
        DungeonConcept.Instance.ChosingTileBaseConcept(tileMapAssetConcept);


    }




    public void PaintTileMap(List<Vector2Int> floorPosition)
    {
        tileMapAssetConcept = MapManager.Instance.TilemapAssetConcept;
        var _tileFloorTileMap = DungeonConcept.Instance.FloorTileMap;
        var _tileFloorTilebase = DungeonConcept.Instance.FloorTileBase;
        TileMapProcesser.Instance.PaintTileMapWithMultipleTileBase(floorPosition, _tileFloorTilebase, _tileFloorTileMap);
        var _wallListPosition = wallProcesser.WallDirectionGenerator(floorPosition);
        var _wallTileBase = DungeonConcept.Instance.WallTileMapDungeon;
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.topWall, DungeonConcept.Instance.TopTileMap, _wallTileBase);
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.botWall, DungeonConcept.Instance.DownTileMap, _wallTileBase);
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.rightWall, DungeonConcept.Instance.RightTileMap, _wallTileBase);
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.leftWall, DungeonConcept.Instance.LeftTileMap, _wallTileBase);
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.topleftWall, DungeonConcept.Instance.TopLeftTileMap, _wallTileBase);
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.toprightWall, DungeonConcept.Instance.TopRightTileMap, _wallTileBase);
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.botleftWall, DungeonConcept.Instance.BotLeftTileMap, _wallTileBase);
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.botrightWall, DungeonConcept.Instance.BotRightTileMap, _wallTileBase);
    }

    public void CreateRoomObjectComponents(int index, List<Vector2Int> wallPostion, List<Vector2Int> floorPositon)
    {
        NotifyRoomToMapManager(index);
        ListRoomObject[index].transform.position = Vector3.zero;
        ListRoomObject[index].GetComponent<RoomObject>().Index = index;
        ObjectPoolManager.Instance.ActiveThePool(RoomObject.name);
        ListRoomObject[index].GetComponent<RoomObject>().ListFloorPosition = new List<Vector2Int>(floorPositon);
        if (index == 0)
        {
            ListRoomObject[index].GetComponent<EnemySpawner>().isComplete = true;
            ListRoomObject[index].GetComponent<RoomObject>().isComplete = true;
        }
        if (index != 0 && index != RoomNumber)
        {
            ListRoomObject[index].GetComponent<EnemySpawner>().RoomIndex = index;
        }
        Tilemap _roomWallTilemap = ListRoomObject[index].transform.Find("RoomWall").GetComponent<Tilemap>();
        TileMapProcesser.Instance.PaintTileMap(wallPostion, DungeonConcept.Instance.WallRoomTileBase, _roomWallTilemap);
        Tilemap _roomFloorTilemap = ListRoomObject[index].transform.Find("RoomFloor").GetComponent<Tilemap>();
        TileMapProcesser.Instance.PaintTileMap(floorPositon, DungeonConcept.Instance.FloorRoomTileBase, _roomFloorTilemap);
    }
    public void NotifyRoomToMapManager(int index)
    {
        MapManager.Instance.Room.Clear();
        MapManager.Instance.Room.Add(ListRoomObject[index]);

    }
    public void AddEnviromentToRoom()
    {
        for (int i = 1; i < ListRoomCenterPosition.Count - 1; i++)
        {
            enviromentGenerator.RandomArchitectureCreate(ListRoomObject[i], ListRoomCenterPosition[i]);
        }


    }
}
