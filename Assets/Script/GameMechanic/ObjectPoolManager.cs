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
    public void SpawnThePool(string namePool, int poolSize) // tao ra pool object tu pool
    {
        var _pool = ListPool.Find(p => p.Name == namePool);
        GameObject _tempParentObject = new GameObject(namePool + "Pool");
        for (int i = 0; i < poolSize; i++)
        {
            var _tempObject = Instantiate(_pool.Prefab);
            _tempObject.name = _pool.Prefab.name + i;
            _tempObject.SetActive(false);
            _tempObject.transform.parent = _tempParentObject.transform;
            _pool.ListGameObject.Add(_tempObject);

        }
    }
    public void SpawnThePool(string namePool, int poolSize, GameObject gameobjectParent)// tao ra pool object tu pool nma duoc gan cho 1 object lam parent 
    {
        var _pool = ListPool.Find(p => p.Name == namePool);
        _pool.ListGameObject.Clear();
        for (int i = 0; i < poolSize; i++)
        {
            var _tempObject = Instantiate(_pool.Prefab);
            _tempObject.name = _pool.Prefab.name + i;
            _tempObject.SetActive(false);
            _tempObject.transform.SetParent(gameobjectParent.transform);
            _pool.ListGameObject.Add(_tempObject);

        }
    }

    public void CreatePoolForDuplicateObject(GameObject poolObject)
    {
        DestroyPoolObject(poolObject.name);
        if (!ListPoolName.Contains(poolObject.name))
        {
            var _tempPool = new Pool();
            _tempPool.Name = poolObject.name;
            _tempPool.Prefab = poolObject;
            _tempPool.ListGameObject = new List<GameObject>();
            ListPool.Add(_tempPool);
            ListPoolName.Add(poolObject.name);
        }
        else
        {
            ClearPoolObject(poolObject.name);
        }


    }


    public void ActiveThePool(string namePool, List<Vector3Int> GameObjectPosition)
    {
        var _tempPool = ListPool.Find(p => p.Name == namePool);
        if (_tempPool != null)
        {
            for (int i = 0; i < _tempPool.ListGameObject.Count; i++)
            {
                _tempPool.ListGameObject[i].transform.position = GameObjectPosition[i];
                _tempPool.ListGameObject[i].SetActive(true);

            }
        }
        else Debug.Log("Missing Pooling object " + namePool);
    }
    public void ActiveThePool(string namePool)
    {
        var _tempPool = ListPool.Find(p => p.Name == namePool);
        if (_tempPool != null)
        {
            for (int i = 0; i < _tempPool.ListGameObject.Count; i++)
            {
                _tempPool.ListGameObject[i].SetActive(true);

            }
        }
    }
    public GameObject GetObjectFromPool(string namePool)

    {
        GameObject _tempOject = null;
        var _tempPool = ListPool.Find(p => p.Name == namePool);

        for (int i = 0; i < _tempPool.ListGameObject.Count; i++)
        {
            if (_tempPool.ListGameObject[i].activeSelf == false)
            {
                _tempOject = _tempPool.ListGameObject[i];
                break;
            }

        }
        return _tempOject;
    }
    public void ClearPoolObject(string namePool)
    {
        var _tempPool = ListPool.Find(p => p.Name == namePool);
        _tempPool.ListGameObject.Clear();
        DestroyPoolObject(namePool);

    }
    public void DestroyPoolObject(string namePool)
    {

        GameObject _tempParentObject = GameObject.Find(namePool + "Pool");
        if (_tempParentObject != null)
        {
            DestroyImmediate(_tempParentObject);

        }

    }
    public void DontDestroyPool(string NamePool)
    {
        GameObject _tempParentObject = GameObject.Find(NamePool + "Pool");
        DontDestroyOnLoad(_tempParentObject);
    }
    public List<GameObject> ListObjectFromPool(string namePool)
    {
        return ListPool.Find(p => p.Name == namePool).ListGameObject;

    }



}