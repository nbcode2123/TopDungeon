using UnityEngine;

namespace Script.GameManager
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }
        public KeyCode ActiveObject = KeyCode.H;
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
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
