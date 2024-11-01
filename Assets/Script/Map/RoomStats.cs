using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomStats : MonoBehaviour
{
    public int Index;
    public HashSet<Vector2Int> Floor;
    public Tilemap Wall;
    public bool isComplete = false;
    public List<GameObject> ListEnemyInRoom = new List<GameObject>();
    public GameObject PrototypeEnemy; //! mau enemy test
    public int NumberEnemy = 5;


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
        if (Index != 1 && (int)data[0] == Index)
        {
            Debug.Log(NumberEnemy);
            for (int i = 0; i < NumberEnemy; i++)
            {
                var _tempEnemyInPool = ObjectPoolManager.Instance.GetObjectFromPool(PrototypeEnemy.name);
                ListEnemyInRoom.Add(_tempEnemyInPool);
                List<Vector2Int> _tempList = new List<Vector2Int>(Floor);
                Vector2Int _Pos = _tempList[Random.Range(0, _tempList.Count + 1)];
                _tempEnemyInPool.transform.position = new Vector3(_Pos.x, _Pos.y, 0);
                _tempEnemyInPool.SetActive(true);
            }


        }


    }

}
