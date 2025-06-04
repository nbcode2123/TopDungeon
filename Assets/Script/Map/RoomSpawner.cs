using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomSpawner : MonoBehaviour
{
    public int RoomIndex; // RoomIndex == Spawner Index thể hiện đây là spawner của phòng nào 
    public int NumberEnemyEachWave;
    public int NumberEnemy = 5;
    public List<Vector2Int> SpawnPoint = new List<Vector2Int>();
    public List<GameObject> EnemyPrefab;
    public bool isComplete = false;
    public List<Vector2Int> ListFloorPosition; //! đang tạo ra thêm 1 list Vector2Int floor Position có thể gây lag nhớ sửa lại 
    public List<GameObject> EnemyInThisRoom = new List<GameObject>();
    public Vector2Int CenterRoomPosition;
    public bool isThisBossStage;

    void Start()
    {
        ObserverManager.AddListener<int>("Enter New Room", CheckNewRoomEnter);
        ObserverManager.AddListener<GameObject>("EnemyDie", EnemyDie);
        // ListFloorPosition = gameObject.GetComponent<RoomObject>().ListFloorPosition;
        // CenterRoomPosition = gameObject.GetComponent<RoomObject>().CenterPosition;
        if (isThisBossStage == false)
        {
            EnemyPrefab = DungeonConcept.Instance.Enemy;

        }



        // CreateSpawnPoint();
        // CreateBulletPoolingForEnemy();
    }

    // public void CreatePoolForEnemy()
    // {
    //     foreach (var _enemy in Enemy)
    //     {
    //         ObjectPoolManager.Instance.CreatePoolForDuplicateObject(_enemy);
    //         ObjectPoolManager.Instance.SpawnThePool(_enemy.name, NumberEnemyPooling);

    //     }

    // }
    // public void CreateBulletPoolingForEnemy()
    // {
    //     if (isThisBossStage == false)
    //     {
    //         foreach (var obj in EnemyPrefab)
    //         {
    //             var _tempBulletObj = obj.GetComponent<RangeAttack>()?.Bullet;
    //             ObjectPoolManager.Instance.CreatePoolForDuplicateObject(_tempBulletObj);
    //             ObjectPoolManager.Instance.SpawnThePool(_tempBulletObj.name, 100);
    //         }
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
        ListFloorPosition = gameObject.GetComponent<RoomObject>().ListFloorPosition; //!
        CenterRoomPosition = gameObject.GetComponent<RoomObject>().CenterPosition;//!
        SpawnPoint = new List<Vector2Int>();
        if (isThisBossStage == false)
        {
            for (int i = 0; i < NumberEnemy; i++)
            {
                SpawnPoint.Add(ListFloorPosition[Random.Range(0, ListFloorPosition.Count)]);
            }
        }
        else
        {
            SpawnPoint.Add(CenterRoomPosition);
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
            if (RoomIndex == EnvironmentManager.Instance.ListRoom.Count - 1)
            {

                ObserverManager.Notify("Room Complete", RoomIndex);
                SpawnTransferGate();
                SpawnCompleteChestEndLevel();
                isComplete = true;
            }
            else if (RoomIndex != EnvironmentManager.Instance.ListRoom.Count - 1)
            {
                ObserverManager.Notify("Room Complete", RoomIndex);
                SpawnCompleteChest();
                isComplete = true;
            }


        }




    }
    public void ActiveSpawner()
    {
        EnemyInThisRoom = new List<GameObject>();
        if (isThisBossStage == false)
        {
            for (int i = 0; i < NumberEnemy; i++)
            {
                var prefab = EnemyPrefab[Random.Range(0, EnemyPrefab.Count)];
                var _enemyObject = Instantiate(prefab, new Vector3(SpawnPoint[i].x, SpawnPoint[i].y, 0), Quaternion.identity);
                _enemyObject.GetComponent<EnemyMarkRoomIndex>().RoomIndex = RoomIndex;
                _enemyObject.SetActive(true);
                EnemyInThisRoom.Add(_enemyObject);
                TrashCan.Instance.TrashObj.Add(_enemyObject);

            }
        }
        else if (isThisBossStage == true)
        {
            GameObject _enemyObject = Instantiate(EnemyPrefab[0], new Vector3(SpawnPoint[0].x, SpawnPoint[0].y, 0), Quaternion.identity);
            EnemyInThisRoom.Add(_enemyObject);
            TrashCan.Instance.TrashObj.Add(_enemyObject);




        }



    }
    public void SpawnCompleteChest()
    {
        if (isThisBossStage == false)
        {
            Vector3 _tempPosition = new Vector3(CenterRoomPosition.x, CenterRoomPosition.y, 0);
            var _chest = Instantiate(GameObjectStorage.Instance.ChestPrefab, _tempPosition, Quaternion.identity);
            TrashCan.Instance.TrashObj.Add(_chest);
        }
        else
        {
            Vector3 _tempPosition = new Vector3(CenterRoomPosition.x, CenterRoomPosition.y - 5, 0);
            var _chest = Instantiate(GameObjectStorage.Instance.ChestPrefab, _tempPosition, Quaternion.identity);
            TrashCan.Instance.TrashObj.Add(_chest);
        }




    }
    public void SpawnCompleteChestEndLevel()
    {
        Vector3 _tempPosition = new Vector3(CenterRoomPosition.x, CenterRoomPosition.y - 5, 0);
        var _chest = Instantiate(GameObjectStorage.Instance.ChestPrefab, _tempPosition, Quaternion.identity);
        TrashCan.Instance.TrashObj.Add(_chest);
    }
    public void SpawnTransferGate()
    {
        Vector3 _tempPosition = new Vector3(CenterRoomPosition.x, CenterRoomPosition.y, 0);
        GameObject _transferGate = Instantiate(GameObjectStorage.Instance.TransferGate, _tempPosition, Quaternion.identity);
        TrashCan.Instance.TrashObj.Add(_transferGate);


    }
    public void BossStageSetPrefab()
    {
        EnemyPrefab.Clear();

        EnemyPrefab = DungeonConcept.Instance.Boss;
    }



}
