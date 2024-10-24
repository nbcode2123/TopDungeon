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
        Vector2 _playerPosition = new Vector2(Player.transform.position.x, Player.transform.position.y);
        var _ListRoom = RoomManager.Instance.ListRoom;
        for (int i = 0; i < _ListRoom.Count; i++)
        {
            if (_playerPosition.x < (_ListRoom[i].RoomPosition.x + _ListRoom[i].Width / 2) && _playerPosition.x > (_ListRoom[i].RoomPosition.x - _ListRoom[i].Width / 2) && _playerPosition.y < (_ListRoom[i].RoomPosition.y + _ListRoom[i].Width / 2) && _playerPosition.y > (_ListRoom[i].RoomPosition.y - _ListRoom[i].Width / 2))
            {
                if (i + 1 == PlayerRoom)
                {
                    return;
                }
                else
                {
                    PlayerRoom = i + 1;
                    Debug.Log("Player go to the new room: " + PlayerRoom);
                    break;
                }
            }
        }

    }
}
