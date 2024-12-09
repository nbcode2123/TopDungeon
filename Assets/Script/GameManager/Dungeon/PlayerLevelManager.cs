using UnityEngine;

namespace Script.GameManager.Dungeon
{
    public class PlayerLevelManager : MonoBehaviour
    {
        public static PlayerLevelManager Instance { get; set; }
        public int PlayerLevel;
        public int PlayerStage;
        public int PlayerRoom;
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



        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}
