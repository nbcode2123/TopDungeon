using UnityEngine;

namespace Script.GameManager.Dungeon
{
    public class GameProgressManager : MonoBehaviour
    {
        public static GameProgressManager Instance { get; private set; }
        public int Coin;
        public int Token;
        public int EnemyCount;
        public int Level;
        public int Stage;
        public int Room;



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
     
    }
}
