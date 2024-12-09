using System.Collections.Generic;
using Script.GameManager.Logic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Script.GameManager.Dungeon
{
    public class RoomManager : MonoBehaviour
    {
        public static RoomManager Instance { get; private set; }
        public List<Vector2Int> RoomPosition = new List<Vector2Int>();
        public List<int> ListRoomSize = new List<int>();
        public List<Room> ListRoom = new List<Room>();
        public List<Tilemap> ListObjectRoom = new List<Tilemap>();
        public List<Tilemap> ListObjectRoomWall = new List<Tilemap>();
        public Dictionary<int, HashSet<Vector2Int>> DicFloorPos = new Dictionary<int, HashSet<Vector2Int>>();
        public int EnemyEachRoom = 5; //** đưa vào GameManager để  quản lý 
        public struct Room
        {
            public int Index; // Số thứ tự của phòng 
            public Vector2Int RoomPosition; // vị trí trung tâm của phòng 
            public int Width; // chiều rộng của phòng
            public HashSet<Vector2Int> FloorPos;
            public Tilemap FloorCollider;
            public Tilemap WallCollider;
            public int NumberEnemy;
            public Room(int index, Vector2Int roomPosition, int width, HashSet<Vector2Int> floorPos, Tilemap floorCollider, Tilemap wallCollider, int numberEnemy)
            {
                Index = index;
                RoomPosition = roomPosition;
                Width = width;
                FloorPos = floorPos;
                FloorCollider = floorCollider;
                WallCollider = wallCollider;
                NumberEnemy = numberEnemy;

            }

        }


        public void Awake()
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


        // Update is called once per frame
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {

            }


        }

        public void CreateListRoom()
        {
            for (int i = 0; i < MapGenerator_Manager.Instance.corridorcount + 1; i++)
            {
                var _tempRoomPosition = RoomPosition.ToArray();

                Room _tempRoom;
                _tempRoom.Index = i + 1;
                _tempRoom.RoomPosition = _tempRoomPosition[i];
                _tempRoom.Width = ListRoomSize[i];
                _tempRoom.FloorPos = DicFloorPos[i];
                _tempRoom.FloorCollider = ListObjectRoom[i];
                _tempRoom.WallCollider = ListObjectRoomWall[i];
                _tempRoom.NumberEnemy = EnemyEachRoom;
                _tempRoom.WallCollider.gameObject.SetActive(false);
                _tempRoom.FloorCollider.GetComponent<RoomControl>().Index = _tempRoom.Index;
                _tempRoom.FloorCollider.GetComponent<RoomControl>().Wall = _tempRoom.WallCollider;
                _tempRoom.FloorCollider.GetComponent<RoomControl>().NumberEnemy = EnemyEachRoom;
                _tempRoom.FloorCollider.GetComponent<RoomControl>().Floor = _tempRoom.FloorPos;


                ListRoom.Add(_tempRoom);
            }
            ObserverManager.Notify("Create List Room Complete");

        }






    }
}