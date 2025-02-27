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

    public void Start()
    {

    }
    // public override void InstallBindings()
    // {

    // }

    public void MapGenerator()
    {
        InitializeGeneration();
        CreateRoomObjectPooling();
        CreateRoomAndColider();
        AddEnviromentToRoom();
        PaintTileMap(FloorPosition);
    }
    public void InitializeGeneration()
    {
        TileMapProcesser.Instance.ClearAllTileMap();
        ListRoomCenterPosition.Clear();
        ListRoomObject.Clear();
        FloorPosition.Clear();
        MapManager.Instance.TilemapAssetConcept = TileMapCollector.Instance.TilebaseCollector[0];


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
            var _tempRoomFloorPosition = roomGenerator.FloorGenerator(_currentPosition, RoomSize);
            FloorPosition.AddRange(_tempRoomFloorPosition);
            if (i != RoomNumber - 1)
            {
                _currentPosition = CreateColider(_currentPosition, coliderDirection[i]);
            }
            var _wallPositionEachRoom = wallProcesser.WallGenerator(_tempRoomFloorPosition);
            CreateRoomObjectComponents(i, _wallPositionEachRoom, _tempRoomFloorPosition);
        }
    }
    public Vector2Int CreateColider(Vector2Int startPostion, Vector2Int direction)
    {
        Vector2Int _currentPosition = startPostion;
        var _colider = coliderGenerator.WalkColider(_currentPosition, SpacingBetweenEachRoom, direction);
        FloorPosition.AddRange(_colider.WalkPosition);
        _currentPosition = _colider.EndPosition;
        while (ListRoomCenterPosition.Contains(_colider.EndPosition))
        {
            _colider = coliderGenerator.WalkColider(_currentPosition, SpacingBetweenEachRoom, direction);
            FloorPosition.AddRange(_colider.WalkPosition);
            _currentPosition = _colider.EndPosition;
        }
        return _currentPosition;

    }




    public void PaintTileMap(List<Vector2Int> floorPosition)
    {
        var _tilebaseInCollector = MapManager.Instance.TilemapAssetConcept;
        TileMapCollector.Instance.ChosingTileBaseConcept(_tilebaseInCollector);
        var _tileFloorTileMap = TileMapCollector.Instance.FloorTileMap;
        var _tileFloorTilebase = TileMapCollector.Instance.FloorTileBase;
        TileMapProcesser.Instance.PaintTileMapWithMultipleTileBase(floorPosition, _tileFloorTilebase, _tileFloorTileMap);
        var _wallListPosition = wallProcesser.WallDirectionGenerator(floorPosition);
        var _wallTileBase = TileMapCollector.Instance.WallTileMapDungeon;
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.topWall, TileMapCollector.Instance.TopTileMap, _wallTileBase);
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.botWall, TileMapCollector.Instance.DownTileMap, _wallTileBase);
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.rightWall, TileMapCollector.Instance.RightTileMap, _wallTileBase);
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.leftWall, TileMapCollector.Instance.LeftTileMap, _wallTileBase);
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.topleftWall, TileMapCollector.Instance.TopLeftTileMap, _wallTileBase);
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.toprightWall, TileMapCollector.Instance.TopRightTileMap, _wallTileBase);
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.botleftWall, TileMapCollector.Instance.BotLeftTileMap, _wallTileBase);
        TileMapProcesser.Instance.PaintTileMap(_wallListPosition.botrightWall, TileMapCollector.Instance.BotRightTileMap, _wallTileBase);
    }

    public void CreateRoomObjectComponents(int index, List<Vector2Int> wallPostion, List<Vector2Int> floorPositon)
    {
        NotifyRoomToMapManager(index);
        ListRoomObject[index].transform.position = Vector3.zero;
        ListRoomObject[index].GetComponent<RoomObject>().Index = index;
        ObjectPoolManager.Instance.ActiveThePool(RoomObject.name);
        Tilemap _roomWallTilemap = ListRoomObject[index].transform.Find("RoomWall").GetComponent<Tilemap>();
        TileMapProcesser.Instance.PaintTileMap(wallPostion, TileMapCollector.Instance.Testting, _roomWallTilemap);
        Tilemap _roomFloorTilemap = ListRoomObject[index].transform.Find("RoomFloor").GetComponent<Tilemap>();
        TileMapProcesser.Instance.PaintTileMap(floorPositon, TileMapCollector.Instance.Testting, _roomFloorTilemap);
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
