using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;

    public class Pool
    {
        public string Name;
        public GameObject Prefab;
        public List<GameObject> ListGameObject;
    }

    public List<Pool> ListPool = new List<Pool>();

    void Awake()
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

    void Start()
    {
        ListPool = new List<Pool>();



    }

    public void SpawnThePool(string NamePool, int PoolSize)
    {
        var _pool = ListPool.Find(p => p.Name == NamePool);
        GameObject _tempParentObject = new GameObject(NamePool + "Pool");
        for (int i = 0; i < PoolSize; i++)
        {
            var _tempObject = Instantiate(_pool.Prefab);
            _tempObject.SetActive(false);
            _tempObject.transform.parent = _tempParentObject.transform;
            _pool.ListGameObject.Add(_tempObject);

        }
    }
    public void CreatePoolForObject(GameObject PoolObject)
    {

        var _tempPool = new Pool();
        _tempPool.Name = PoolObject.name;
        _tempPool.Prefab = PoolObject;
        _tempPool.ListGameObject = new List<GameObject>();
        ListPool.Add(_tempPool);
    }
    public void ActiveThePool(string NamePool, List<Vector3> GameObjectPosition)
    {
        var _tempPool = ListPool.Find(p => p.Name == NamePool);
        if (_tempPool != null)
        {
            for (int i = 0; i < _tempPool.ListGameObject.Count; i++)
            {
                _tempPool.ListGameObject[i].GetComponent<EnemyReBornable>()?.ReBornActor();
                _tempPool.ListGameObject[i].transform.position = GameObjectPosition[i];
                _tempPool.ListGameObject[i].SetActive(true);

            }
        }
        else Debug.Log("Missing Pooling object " + NamePool);
    }


}