using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

[RequireComponent(typeof(ObserverManager))]
[RequireComponent(typeof(UIManager))]
[RequireComponent(typeof(CustomizeSceneManager))]

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [field: SerializeField] public GameObject Player { get; set; }
    [field: SerializeField] public KeyCode AttackButton = KeyCode.Mouse0;

    public GameObject tempWeapon;

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
        ObserverManager.AddListener("EnterWeapon", ChangeTempWeapon);
        ObserverManager.AddListener("OutWeapon", RemoveTempWeapon);




    }

    // Update is called once per frame
    void Update()
    {




    }
    public void ChangeTempWeapon(object[] data)
    {
        if (data.Length >= 2 && tempWeapon == null)
        {
            tempWeapon = (GameObject)data[1];

        }
    }
    public void RemoveTempWeapon(object[] data)
    {
        tempWeapon = null;
    }



}
