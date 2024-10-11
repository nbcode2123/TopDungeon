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
    public List<string> ListPoolName = new List<string>();

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
        ListPool = new List<Pool>();

    }

    void Start()
    {



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
    public void SpawnThePool(string NamePool, int PoolSize, GameObject gameobjectParent)
    {
        var _pool = ListPool.Find(p => p.Name == NamePool);
        for (int i = 0; i < PoolSize; i++)
        {
            var _tempObject = Instantiate(_pool.Prefab);
            _tempObject.SetActive(false);
            _tempObject.transform.SetParent(gameobjectParent.transform);
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
        ListPoolName.Add(PoolObject.name);
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
    public GameObject SingleObject(string NamePool)

    {
        GameObject _tempOject = null;
        var _tempPool = ListPool.Find(p => p.Name == NamePool);
        {
            for (int i = 0; i < _tempPool.ListGameObject.Count; i++)
            {
                if (_tempPool.ListGameObject[i].activeSelf == false)
                {
                    _tempOject = _tempPool.ListGameObject[i];
                    break;
                }


            }
        }
        return _tempOject;
    }



}