using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; set; }
    public List<GameObject> ListEnemy;
    public int Difficulty;
    public int NumberEnemy;

    private void Awake()
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


    // Start is called before the first frame update
    void Start()
    {
        ObserverManager.AddListener("Create List Room Complete", CreateObjectPoolForHoldMap);



    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CreateObjectPoolForHoldMap(object[] data)
    {
        ObjectPoolManager.Instance.CreatePoolForObject(ListEnemy[0]);
        ObjectPoolManager.Instance.SpawnThePool(ListEnemy[0].name, NumberEnemy);


    }


}
