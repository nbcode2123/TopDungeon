using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Script.GameManager.Logic
{
    public class RoomControl : MonoBehaviour
    {
        public int Index;
        public HashSet<Vector2Int> Floor;
        public Tilemap Wall;
        public bool isComplete = false;
        public List<GameObject> ListEnemyInRoom = new List<GameObject>();
        public GameObject PrototypeEnemy; //! mau enemy test
        public int NumberEnemy;


        // Start is called before the first frame update
        void Start()
        {
            ObserverManager.AddListener("Enter New Room", ActiveWall);
            ObserverManager.AddListener("Enter New Room", ActiveEnemy);
            if (Index == 1)
            {
                ObserverManager.RemoveListener("Enter New Room", ActiveWall);
                ObserverManager.RemoveListener("Enter New Room", ActiveEnemy);
            }
            ObserverManager.AddListener("Enemy Die", CheckEnemyInRoom);






        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ActiveWall(object[] data)
        {
            if (data.Length >= 1)
            {
                if ((int)data[0] == Index && isComplete == false && Index != 1)
                {
                    Wall.gameObject.SetActive(true);
                }
                else return;

            }

        }
        public void ActiveEnemy(object[] data)
        {

            if (isComplete == false && Index != 1 && (int)data[0] == Index)
            {
                for (int i = 0; i < NumberEnemy; i++)
                {
                    var _tempEnemyInPool = ObjectPoolManager.Instance.GetObjectFromPool(PrototypeEnemy.name);
                    if (_tempEnemyInPool.GetComponent<RoomChecker>() == null)
                    {
                        _tempEnemyInPool.AddComponent<RoomChecker>().RoomIndex = Index;
                    }
                    else
                    {
                        _tempEnemyInPool.GetComponent<RoomChecker>().RoomIndex = Index;

                    }

                    List<Vector2Int> _tempList = new List<Vector2Int>(Floor);
                    Vector2Int _Pos = _tempList[Random.Range(0, _tempList.Count + 1)];
                    _tempEnemyInPool.transform.position = new Vector3(_Pos.x, _Pos.y, 0);
                    _tempEnemyInPool.SetActive(true);
                    ListEnemyInRoom.Add(_tempEnemyInPool);


                }
            }


        }

        void OnDestroy()
        {
            ObserverManager.RemoveListener("Enter New Room", ActiveWall);
            ObserverManager.RemoveListener("Enter New Room", ActiveEnemy);
            ObserverManager.RemoveListener("Enemy Die", CheckEnemyInRoom);
        }
        public void CheckEnemyInRoom(object[] data)
        {
            if ((int)data[0] == Index)
            {
                if (ListEnemyInRoom.Contains((GameObject)data[1]))
                {
                    ListEnemyInRoom.Remove((GameObject)data[1]);
                    CheckRoomComplete();
                }

            }

        }
        private void CheckRoomComplete()
        {
            if (ListEnemyInRoom.Count == 0)
            {
                isComplete = true;
                Wall.gameObject.SetActive(false);
                ObserverManager.Notify("Room Complete", Index);

            }
        }

    }
}
