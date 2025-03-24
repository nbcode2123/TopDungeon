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
    public void CreateSpawnPoint()
    {
        for (int i = 0; i < NumberEnemy; i++)
        {
            SpawnPoint.Add(ListFloorPosition[Random.Range(0, ListFloorPosition.Count)]);
        }

    }
    public void CheckNewRoomEnter(int _indexSpawner)
    {
        if (_indexSpawner == RoomIndex && isComplete == false)
        {
            Debug.Log("ActiveSpawner");
            ActiveSpawner();
        }

    }
    public void ActiveSpawner()
    {
        for (int i = 0; i < NumberEnemy; i++)
        {
            var prefab = EnemyPrefab[Random.Range(0, EnemyPrefab.Count)];
            var _enemyObject = Instantiate(prefab, new Vector3(SpawnPoint[i].x, SpawnPoint[i].y, 0), Quaternion.identity);
            EnemyInThisRoom.Add(_enemyObject);

        }

    }


}
