using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject ChosingWeaponAlert;
    public GameObject ChosingWeaponName;
    public static UIManager Instance { get; private set; }
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



    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        ObserverManager.AddListener("EnterNewRoom ", AlertWhenEnterNewRoom);
        ObserverManager.AddListener("EnterWeapon", AlertWhenTakeNewWeapon);
        ObserverManager.AddListener("OutWeapon", TurnOffAlerNewWeapon);

    }



    void OnDestroy()
    {
        ObserverManager.RemoveListener("EnterNewRoom ", AlertWhenEnterNewRoom);
    }
    public void AlertWhenEnterNewRoom(params object[] data)
    {
        Debug.Log("Enter new  Room");
    }
    void AlertWhenTakeNewWeapon(object[] data)
    {
        ChosingWeaponAlert.SetActive(true);
        if (data.Length >= 1)
        {
            ChosingWeaponName.GetComponent<TextMeshProUGUI>().text = "Press Space to take " + (string)data[0];

        }

    }
    void TurnOffAlerNewWeapon(object[] data)
    {
        ChosingWeaponAlert.SetActive(false);


    }







}
