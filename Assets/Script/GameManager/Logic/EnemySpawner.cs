using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int TempNumberOfEnemy = 4;
    public GameObject EyeBatEnemy;
    public struct RoomSpawner
    {
        public RoomManager.Room Room; // Phòng gắn spawner
        public List<Vector2> SpawnPosition; // vij trí enemy
        public int NumberOfEnemy; // số lượng enemy

    }
    public List<RoomSpawner> ListRoomSpawner = new List<RoomSpawner>();
    // Start is called before the first frame update

    private void Start()
    {
        // ObserverManager.AddListener("Create Room Complete", SpawnEnemyInEachRoom);



    }
    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnEnemyInEachRoom()
    {
        CreateSpawnerInEachRoom(); // tạo ra spawner trong các phòng 
        int maxEnemyInRoom = 0;
        for (int i = 0; i < ListRoomSpawner.Count; i++)
        {
            if (ListRoomSpawner[i].NumberOfEnemy > maxEnemyInRoom)
            {
                maxEnemyInRoom = ListRoomSpawner[i].NumberOfEnemy;

            }
        }
        ObjectPoolManager.Instance.CreatePoolForObject(EyeBatEnemy);
        ObjectPoolManager.Instance.SpawnThePool(EyeBatEnemy.name, maxEnemyInRoom);

    }
    private void CreateSpawnerInEachRoom()
    {
        ListRoomSpawner = new List<RoomSpawner>(); // làm mới danh  sách các phòng gồm các điểm spawn và số lượng enemy
        int _NumberOfRoom = RoomManager.Instance.ListRoom.Count;

        RoomSpawner _tempRoomSpawner = new RoomSpawner();
        _tempRoomSpawner.Room = RoomManager.Instance.ListRoom[0];
        _tempRoomSpawner.SpawnPosition = null;

        _tempRoomSpawner.NumberOfEnemy = 0;
        ListRoomSpawner.Add(_tempRoomSpawner);


        for (int i = 1; i < _NumberOfRoom; i++)
        {
            _tempRoomSpawner = new RoomSpawner();
            _tempRoomSpawner.Room = RoomManager.Instance.ListRoom[i];
            _tempRoomSpawner.SpawnPosition = CreateSpawnPosition(RoomManager.Instance.ListRoom[i].RoomPosition, RoomManager.Instance.ListRoom[i].Width, TempNumberOfEnemy);
            _tempRoomSpawner.NumberOfEnemy = TempNumberOfEnemy;
            ListRoomSpawner.Add(_tempRoomSpawner);
        }

    }
    private List<Vector2> CreateSpawnPosition(Vector2 RoomPosition, int RoomSize, int NumberOfEnemy) // tạo điểm spawn dựa trên kích thước phòng vị trí phòng và số lượng kể địch 
    {
        var _tempListSpawnPosition = new List<Vector2>();
        for (int i = 0; i < NumberOfEnemy; i++)
        {

            float x = Random.Range(RoomPosition.x - RoomSize / 2, RoomPosition.x + (RoomSize / 2));
            float y = Random.Range(RoomPosition.y - RoomSize / 2, RoomPosition.y + (RoomSize / 2));

            var _tempSpawnPosition = new Vector2(x, y);
            _tempListSpawnPosition.Add(_tempSpawnPosition);


        }
        return _tempListSpawnPosition;




    }



}
