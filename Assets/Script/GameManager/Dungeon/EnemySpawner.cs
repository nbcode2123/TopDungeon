using System.Collections.Generic;
using UnityEngine;

namespace Script.GameManager.Dungeon
{
    public class EnemySpawner : MonoBehaviour
    {
        public static EnemySpawner Instance { get; set; }
        public List<GameObject> ListEnemy;
        public int Difficulty;
        public int NumberEnemy;

        public void Awake()
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
        public void Start()
        {
            ObserverManager.AddListener("Create List Room Complete", CreateObjectPoolForHoldMap);



        }

        // Update is called once per frame
        public void Update()
        {

        }
        public void CreateObjectPoolForHoldMap(object[] data)
        {
            if (!ObjectPoolManager.Instance.ListPoolName.Contains(ListEnemy[0].name))
            {
                ObjectPoolManager.Instance.CreatePoolForObject(ListEnemy[0]);
                ObjectPoolManager.Instance.SpawnThePool(ListEnemy[0].name, NumberEnemy);
            }



        }


    }
}
