using TMPro;
using UnityEngine;

namespace Script.GameManager
{
    public class UIManager : MonoBehaviour
    {
        public GameObject ChosingWeaponAlert;
        public GameObject ChosingWeaponName;
        public GameObject Canvas;
        public GameObject AlertRoomCompleteUI;
        public static UIManager Instance { get; private set; }
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



        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        public void Start()
        {
            ObserverManager.AddListener("Enter New Room ", AlertWhenEnterNewRoom);
            ObserverManager.AddListener("EnterWeapon", AlertWhenTakeNewWeapon);
            ObserverManager.AddListener("OutWeapon", TurnOffAlerNewWeapon);
            ObserverManager.AddListener("Room Complete", AlertRoomComplete);
            DontDestroyOnLoad(Canvas);

        }



        public void OnDestroy()
        {
            ObserverManager.RemoveListener("EnterNewRoom ", AlertWhenEnterNewRoom);
        }
        public void AlertWhenEnterNewRoom(params object[] data)
        {
            Debug.Log("Enter new  Room");
        }
        public void AlertWhenTakeNewWeapon(object[] data)
        {
            ChosingWeaponAlert.SetActive(true);
            if (data.Length >= 1)
            {
                ChosingWeaponName.GetComponent<TextMeshProUGUI>().text = "Press " + InputManager.Instance.ActiveObject.ToString() + " to take " + (string)data[0];

            }

        }
        public void TurnOffAlerNewWeapon(object[] data)
        {
            ChosingWeaponAlert.SetActive(false);


        }
        public void AlertRoomComplete(object[] data)
        {

        }








    }
}
