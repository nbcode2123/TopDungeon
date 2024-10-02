using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(RoomManager))]
[RequireComponent(typeof(PlayerLevelManager))]
public class DungeonManager : MonoBehaviour
{
    public GameObject Camera;
    public GameObject MapManager;


    public static DungeonManager Instance { get; private set; }

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
        if (GameManager.Instance.Player != null)
        {
            GameManager.Instance.Player.transform.position = Vector3.zero;
            Camera.GetComponent<CinemachineVirtualCamera>().Follow = GameManager.Instance.Player.transform;
        }
        else return;
    }

    // Update is called once per frame
    void Update()
    {



    }

}
