using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLevelManager : MonoBehaviour
{
    public static PlayerLevelManager Instance { get; set; }
    private GameObject Player;
    public int PlayerLevel;
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
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameManager.Instance.Player;
        PlayerRoom = 0;
        PlayerLevel = 1;
        ObserverManager.AddListener("Player Move", CheckPlayerRoom);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckPlayerRoom(params object[] data)
    {


    }
}
