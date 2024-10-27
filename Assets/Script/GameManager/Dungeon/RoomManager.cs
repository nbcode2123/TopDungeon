using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.Tilemaps;


[RequireComponent(typeof(EnemySpawner))]
public class RoomManager : MonoBehaviour
{
    public List<Vector2Int> RoomPosition;
    public Vector2Int currentRoomPosition = Vector2Int.zero;
    public int RoomIndexPlayerStanding;
    public List<int> ListRoomSize = new List<int>();
    public List<Room> ListRoom = new List<Room>();
    public GameObject Player;
    private EnemySpawner enemySpawner;
    public static RoomManager Instance { get; private set; }
    public int _tempRoomIndex = 0;
    public GameObject testGameObject; // test se xoa di 
    public List<Tilemap> ListObjectRoom = new List<Tilemap>();

    public Dictionary<int, HashSet<Vector2Int>> DicFloorPos = new Dictionary<int, HashSet<Vector2Int>>();
    public struct Room
    {
        public int Index; // Số thứ tự của phòng 
        public Vector2Int RoomPosition; // vị trí trung tâm của phòng 
        public int Width; // chiều rộng của phòng
        public HashSet<Vector2Int> FloorPos;
        public Tilemap FloorCollider;
        public Room(int index, Vector2Int roomPosition, int width, HashSet<Vector2Int> floorPos, Tilemap floorCollider)
        {
            Index = index;
            RoomPosition = roomPosition;
            Width = width;
            FloorPos = floorPos;
            FloorCollider = floorCollider;


        }

    }
    public PaintTilemap paintTilemap;


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


    }


    // Start is called before the first frame update
    void Start()
    {
        Player = GameManager.Instance.Player;
        RoomIndexPlayerStanding = 1;
        enemySpawner = gameObject.GetComponent<EnemySpawner>();




    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            // ActiveEnemyInRoom();
        }


    }

    public void CreateListRoom()
    {

        // for (int i = 0; i < MapGenerator_Manager.Instance.corridorcount; i++)
        // {
        //     Room _tempRoom;
        //     _tempRoom.FloorPos = DicFloorPos[i];




        // }

        for (int i = 0; i < MapGenerator_Manager.Instance.corridorcount; i++)
        {
            var _tempRoomPosition = RoomPosition.ToArray();

            Room _tempRoom;
            _tempRoom.Index = i + 1;
            _tempRoom.RoomPosition = _tempRoomPosition[i];
            _tempRoom.Width = ListRoomSize[i];
            _tempRoom.FloorPos = DicFloorPos[i];
            _tempRoom.FloorCollider = ListObjectRoom[i];

            ListRoom.Add(_tempRoom);

        }




        ObserverManager.Notify("Create Room Complete");

    }




    public void ActiveEnemyInRoom()
    {
        Debug.Log(enemySpawner.ListRoomSpawner.Count);
        _tempRoomIndex += 1;
        var _tempCurrentRoom = enemySpawner.ListRoomSpawner[_tempRoomIndex];
        var _tempListPositionConvertToVector3 = new List<Vector3>();

        Debug.Log(_tempCurrentRoom.SpawnPosition.Count);


        for (int i = 0; i < _tempCurrentRoom.SpawnPosition.Count; i++)
        {
            _tempListPositionConvertToVector3.Add(new Vector3(_tempCurrentRoom.SpawnPosition[i].x, _tempCurrentRoom.SpawnPosition[i].y, 0));
        }

        ObjectPoolManager.Instance.ActiveThePool(enemySpawner.EyeBatEnemy.name, _tempListPositionConvertToVector3);



    }


}