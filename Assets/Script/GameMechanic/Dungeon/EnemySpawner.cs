using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int RoomIndex; // RoomIndex == Spawner Index thể hiện đây là spawner của phòng nào 
    public int NumberEnemyEachWave;
    public int NumberEnemy = 5;
    public int NumberEnemyPooling = 10;
    public List<Vector2Int> SpawnPoint = new List<Vector2Int>();
    public List<GameObject> EnemyPrefab;
    public bool isComplete = false;
    public List<Vector2Int> ListFloorPosition; //! đang tạo ra thêm 1 list Vector2Int floor Position có thể gây lag nhớ sửa lại 
    public List<GameObject> EnemyInThisRoom = new List<GameObject>();

    void Start()
    {
        ObserverManager.AddListener<int>("Enter New Room", CheckNewRoomEnter);
        ObserverManager.AddListener<GameObject>("EnemyDie", EnemyDie);
        ListFloorPosition = gameObject.GetComponent<RoomObject>().ListFloorPosition;
        EnemyPrefab = DungeonConcept.Instance.Enemy;
        CreateSpawnPoint();
    }

    // public void CreatePoolForEnemy()
    // {
    //     foreach (var _enemy in Enemy)
    //     {
    //         ObjectPoolManager.Instance.CreatePoolForDuplicateObject(_enemy);
    //         ObjectPoolManager.Instance.SpawnThePool(_enemy.name, NumberEnemyPooling);

    //     }

    // }
    void OnDisable()
    {
        ObserverManager.RemoveListener<int>("Enter New Room", CheckNewRoomEnter);

        ObserverManager.RemoveListener<GameObject>("EnemyDie", EnemyDie);




    }
    void OnDestroy()
    {
        ObserverManager.RemoveListener<int>("Enter New Room", CheckNewRoomEnter);
        ObserverManager.RemoveListener<GameObject>("EnemyDie", EnemyDie);


    }
    public void Complete(int _indexSpawner)
    {
        if (_indexSpawner == RoomIndex)
        {
            isComplete = true;
        }
    }

    public void CreateSpawnPoint()
    {
        SpawnPoint = new List<Vector2Int>();
        for (int i = 0; i < NumberEnemy; i++)
        {
            SpawnPoint.Add(ListFloorPosition[Random.Range(0, ListFloorPosition.Count)]);
        }

    }
    public void CheckNewRoomEnter(int _indexSpawner)
    {
        if (_indexSpawner == RoomIndex && isComplete == false)
        {
            ActiveSpawner();
        }

    }
    public void EnemyDie(GameObject enemy)
    {
        if (EnemyInThisRoom.Contains(enemy))
        {
            EnemyInThisRoom.Remove(enemy);
        }
        if (EnemyInThisRoom.Count == 0 && DungeonController.Instance.CurrentRoom == RoomIndex)
        {
            ObserverManager.Notify("Room Complete", RoomIndex);
            isComplete = true;
        }



    }
    public void ActiveSpawner()
    {
        EnemyInThisRoom = new List<GameObject>();
        for (int i = 0; i < NumberEnemy; i++)
        {
            var prefab = EnemyPrefab[Random.Range(0, EnemyPrefab.Count)];
            var _enemyObject = Instantiate(prefab, new Vector3(SpawnPoint[i].x, SpawnPoint[i].y, 0), Quaternion.identity);
            _enemyObject.GetComponent<EnemyMarkRoomIndex>().RoomIndex = RoomIndex;
            _enemyObject.SetActive(true);
            EnemyInThisRoom.Add(_enemyObject);

        }

    }


}
