using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;


public class MapProcessor : MonoBehaviour
{
    public static MapProcessor Instance { get; private set; }
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;

        }

        // MapGenerator();
    }
    // public GameObject TextMeshPro;
    public RoomGenerator roomGenerator;  // chua cac phuong thuc tao ra cac thanh phan cua 1 room bao gom floor, wall
    public TileMapProcessor TileMapProcessor;  // chua cac phuong thuc de paint tile map 
    // public ColliderDirection ColliderDirection;
    public ColliderGenerator colliderGenerator; // chua cac phuong thuc ve hanh lang (colider)
    public WallProcesser wallProcesser;
    public EnvironmentGenerator environmentGenerator;
    [SerializeField] private int RoomSize = 35;
    public int RoomNumber;
    public int SpacingBetweenEachRoom;
    public GameObject RoomObject;
    public List<Vector2Int> FloorPosition;
    public List<Vector2Int> ListRoomCenterPosition; // co the xoa 
    public List<GameObject> ListRoomObject;
    public TileMapAssetConcept tileMapAssetConcept;
    public List<Vector2Int> WallPosition;
    public List<Vector2Int> ColliderDirection;
    void OnEnable()
    {
        // ObserverManager.AddListener("DungeonStart", MapGenerator); //! kiem tra trong rangeweapon

    }
    void OnDisable()
    {
        // ObserverManager.RemoveListener("DungeonStart", MapGenerator);

    }
    void OnDestroy()
    {
        // ObserverManager.RemoveListener("DungeonStart", MapGenerator);


    }


    public void Start()
    {

        // ColliderDirection = gameObject.GetComponent<ColliderDirection>();
        // TileMapProcessor = gameObject.GetComponent<TileMapProcessor>();
        // roomGenerator = gameObject.GetComponent<RoomGenerator>();
        // wallProcesser = gameObject.GetComponent<WallProcesser>();
        // environmentGenerator = gameObject.GetComponent<EnvironmentGenerator>();




    }
    public void LoadMapFileSave()
    {

    }
    public void SaveMapFileSave()
    {

    }
    // public void TextChange(string text)
    // {
    //     TextMeshPro.GetComponent<TextMeshProUGUI>().text = text;

    // }


    public void MapGenerator()
    {

        ObserverManager.Notify("Map Generator Start");
        InitializeGeneration();
        Debug.Log("khoi tao lai map");
        // TextChange("khoi tao lai map");
        DecideConcept();
        // TextChange("Concept");


        CreateRoomObjectPooling(); // rao ra pool cho object dai dien cho cac room
        // TextChange("RoomObject pooling");



        CreateRoomAndCollider();
        // TextChange("Create room and collider");

        Debug.Log("Tao phong va hanh lang ");

        PaintTileMap(FloorPosition);
        // TextChange("Too tile map");

        Debug.Log("To mau tile map  ");

        AddEnvironmentToRoom();
        // TextChange("tao moi truong");

        Debug.Log("Tao moi truong  ");


        ObserverManager.Notify("Map Generator Complete");
        // TextChange("Hoang thanh tao map");

        Debug.Log("Hoan thanh tai map  ");
        for (int i = 0; i < ListRoomObject.Count; i++)
        {
            ListRoomObject[i].GetComponent<RoomSpawner>().CreateSpawnPoint();

        }

        // LoadingProgressReporter.Instance.WaitScene.SetActive(false);
        ObserverManager.Notify("DungeonStart");
        // TextChange("dungeon start");

        PropertyDungeon.Instance.LoadingSceneCanvas.SetActive(false);
        UIManager.Instance.PlayerStatsCanvas.SetActive(true);




    }
    public void StartMapProcess()
    {
        MapGenerator();
    }

    public void InitializeGeneration()
    {
        Debug.Log("Khoi tao map ");
        try
        {
            EnvironmentManager.Instance.ListRoom.Clear();
            TileMapProcessor.Instance.ClearAllTileMap(); // clear tat ca cac tilemap 
            ListRoomCenterPosition.Clear(); // clear vi tri trung tam cua cac phong
            if (ListRoomObject.Count > 0)
            {
                for (int i = 0; i < ListRoomObject.Count; i++)
                {
                    Destroy(ListRoomObject[i].gameObject);

                }
            }
            ListRoomObject.Clear(); // clear cac object dai dien cho room

            FloorPosition.Clear(); // clear danh sach vi tri floor 
            EnvironmentManager.Instance.TilemapAssetConcept = DungeonConcept.Instance.TilebaseCollection[0]; //! lay ra concept map, nho code lai 
        }
        catch (Exception ex)
        {

            Debug.LogError("Lỗi khi gọi CreateRoomAndCollider: " + ex.Message);
        }



    }

    public void CreateRoomObjectPooling()
    {


        for (int i = 0; i < RoomNumber; i++)
        {
            GameObject _tempRoomObj = Instantiate(RoomObject);
            _tempRoomObj.name = "Room" + i;
            ListRoomObject.Add(_tempRoomObj);
        }

    }
    public List<Vector2Int> CreateColliderDirection()
    {
        string filePathDirection = Path.Combine(Application.persistentDataPath, "Direction.json");

        if (FileChecker.CheckFile(filePathDirection))
        {
            return DataSaver.LoadListFromJson(filePathDirection);

        }
        else
        {
            colliderGenerator.ColliderDirectionGenerator(RoomNumber); //! 
            ColliderDirection = new List<Vector2Int>(colliderGenerator.ColliderDirection);
            return colliderGenerator.ColliderDirection;
        }





    }
    public void DecideConcept()
    {
        string filePathConcept = Path.Combine(Application.persistentDataPath, "ConceptId.json");

        if (FileChecker.CheckFile(filePathConcept))
        {
            var _idConceptData = DataLoader.DataConceptId();
            DungeonConcept.Instance.ChooseTilebaseConceptWithId(_idConceptData);
            DataDelete.DeleteAllFilePath();


        }
        else
        {
            DungeonConcept.Instance.ChoosingRandomTileBaseConcept();
            EnvironmentManager.Instance.TilemapAssetConcept = DungeonConcept.Instance.CurrentTileMapAsset;
        }



    }




    public void PaintTileMap(List<Vector2Int> floorPosition)
    {
        try
        {
            // tileMapAssetConcept = EnvironmentManager.Instance.TilemapAssetConcept;
            var _tileFloorTileMap = DungeonConcept.Instance.FloorTileMap;
            var _tileFloorTilebase = DungeonConcept.Instance.FloorTileBase;
            StartCoroutine(TileMapProcessor.Instance.PaintTileMapWithMultipleTileBase(floorPosition, _tileFloorTilebase, _tileFloorTileMap));
            WallPosition = new List<Vector2Int>(wallProcesser.WallGenerator(floorPosition));
            var _wallListPosition = wallProcesser.WallDirectionGenerator(floorPosition);
            var _wallTileBase = DungeonConcept.Instance.WallTileMapDungeon;

            TileMapProcessor.Instance.PaintTileMap(_wallListPosition.topWall, DungeonConcept.Instance.TopTileMap, _wallTileBase);
            TileMapProcessor.Instance.PaintTileMap(_wallListPosition.botWall, DungeonConcept.Instance.DownTileMap, _wallTileBase);
            TileMapProcessor.Instance.PaintTileMap(_wallListPosition.rightWall, DungeonConcept.Instance.RightTileMap, _wallTileBase);
            TileMapProcessor.Instance.PaintTileMap(_wallListPosition.leftWall, DungeonConcept.Instance.LeftTileMap, _wallTileBase);
            TileMapProcessor.Instance.PaintTileMap(_wallListPosition.topleftWall, DungeonConcept.Instance.TopLeftTileMap, _wallTileBase);
            TileMapProcessor.Instance.PaintTileMap(_wallListPosition.toprightWall, DungeonConcept.Instance.TopRightTileMap, _wallTileBase);
            TileMapProcessor.Instance.PaintTileMap(_wallListPosition.botleftWall, DungeonConcept.Instance.BotLeftTileMap, _wallTileBase);
            TileMapProcessor.Instance.PaintTileMap(_wallListPosition.botrightWall, DungeonConcept.Instance.BotRightTileMap, _wallTileBase);
        }
        catch (Exception ex)
        {

            Debug.LogError("Lỗi khi gọi CreateRoomAndCollider: " + ex.Message);
        }

    }
    public void CreateRoomAndCollider()
    {


        var _colliderDirection = CreateColliderDirection();
        CreateRoom(_colliderDirection, Vector2Int.zero);

    }
    public void CreateRoom(List<Vector2Int> coliderDirection, Vector2Int startPosition)
    {

        var _currentPosition = startPosition;
        for (int i = 0; i < RoomNumber; i++)
        {
            ListRoomCenterPosition.Add(_currentPosition);
            var _floorPositionEachRoom = roomGenerator.FloorGenerator(_currentPosition, RoomSize);

            FloorPosition.AddRange(_floorPositionEachRoom);
            if (i != RoomNumber - 1)
            {
                _currentPosition = CreateCollider(_currentPosition, coliderDirection[i]);
            }
            var _wallPositionEachRoom = wallProcesser.WallGenerator(_floorPositionEachRoom);
            CreateRoomObjectComponents(i, _wallPositionEachRoom, _floorPositionEachRoom);
        }
    }
    public Vector2Int CreateCollider(Vector2Int startPosition, Vector2Int direction)
    {
        Vector2Int _currentPosition = startPosition;
        var _collider = colliderGenerator.WalkColider(_currentPosition, SpacingBetweenEachRoom + RoomSize, direction);

        FloorPosition.AddRange(_collider.WalkPosition);
        _currentPosition = _collider.EndPosition;
        while (ListRoomCenterPosition.Contains(_collider.EndPosition))
        {
            _collider = colliderGenerator.WalkColider(_currentPosition, SpacingBetweenEachRoom + RoomSize, direction);
            FloorPosition.AddRange(_collider.WalkPosition);
            _currentPosition = _collider.EndPosition;
        }
        return _currentPosition;

    }


    public void CreateRoomObjectComponents(int index, List<Vector2Int> wallPosition, List<Vector2Int> floorPosition)
    {
        NotifyRoomToEnvironmentManager(index);
        ListRoomObject[index].transform.position = Vector3.zero;
        ListRoomObject[index].GetComponent<RoomObject>().Index = index;
        ObjectPoolManager.Instance.ActiveThePool(RoomObject.name);
        ListRoomObject[index].GetComponent<RoomObject>().ListFloorPosition = new List<Vector2Int>(floorPosition);
        ListRoomObject[index].GetComponent<RoomObject>().ListWallPosition = new List<Vector2Int>(wallPosition);

        ListRoomObject[index].GetComponent<RoomObject>().CenterPosition = ListRoomCenterPosition[index];
        bool _isBossStage = DungeonController.Instance.isBossStage;
        ListRoomObject[index].GetComponent<RoomSpawner>().RoomIndex = index;


        if (index == 0)
        {
            ListRoomObject[index].GetComponent<RoomSpawner>().isComplete = true;
            ListRoomObject[index].GetComponent<RoomObject>().isComplete = true;
            ListRoomObject[index].GetComponent<RoomSpawner>().isThisBossStage = false;

        }
        if (index != 0 && index != RoomNumber - 1)
        {
            ListRoomObject[index].GetComponent<RoomSpawner>().isThisBossStage = false;

        }
        else if (index != 0 && index == RoomNumber - 1 && _isBossStage == true)
        {
            ListRoomObject[index].GetComponent<RoomSpawner>().isThisBossStage = true;
            ListRoomObject[index].GetComponent<RoomSpawner>().BossStageSetPrefab();
        }
        else if (index != 0 && index == RoomNumber - 1 && _isBossStage == false)
        {

            ListRoomObject[index].GetComponent<RoomSpawner>().isThisBossStage = false;

        }
        Tilemap _roomWallTilemap = ListRoomObject[index].transform.Find("RoomWall").GetComponent<Tilemap>();
        TileMapProcessor.Instance.PaintTileMap(wallPosition, DungeonConcept.Instance.WallRoomTileBase, _roomWallTilemap);
        Tilemap _roomFloorTilemap = ListRoomObject[index].transform.Find("RoomFloor").GetComponent<Tilemap>();
        TileMapProcessor.Instance.PaintTileMap(floorPosition, DungeonConcept.Instance.FloorRoomTileBase, _roomFloorTilemap);
    }
    public void NotifyRoomToEnvironmentManager(int index)
    {
        EnvironmentManager.Instance.ListRoom.Add(ListRoomObject[index]);

    }
    public void AddEnvironmentToRoom()
    {

        try
        {
            for (int i = 1; i < ListRoomCenterPosition.Count - 1; i++)
            {
                environmentGenerator.RandomArchitectureCreate(ListRoomObject[i], ListRoomCenterPosition[i]);
            }
        }
        catch (Exception ex)
        {

            Debug.LogError("Lỗi khi gọi CreateEnvironment: " + ex.Message);
        }


    }
}
