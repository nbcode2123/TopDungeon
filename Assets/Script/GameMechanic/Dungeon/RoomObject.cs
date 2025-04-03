using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomObject : MonoBehaviour
{
    public int Index;
    public GameObject FloorObject;
    public GameObject WallObject;
    public bool isComplete = false;
    public List<Vector2Int> ListFloorPosition;


    // Start is called before the first frame update
    void Start()
    {
        FloorObject = transform.Find("RoomFloor").gameObject;
        WallObject = transform.Find("RoomWall").gameObject;
        WallObject.SetActive(false);
        ObserverManager.AddListener<int>("Enter New Room", ActiveRoom);
        ObserverManager.AddListener<int>("Room Complete", RoomComplete);

    }
    void OnDisable()
    {
        ObserverManager.RemoveListener<int>("Enter New Room", ActiveRoom);

    }
    void OnDestroy()
    {
        ObserverManager.RemoveListener<int>("Enter New Room", ActiveRoom);

    }
    public void ActiveRoom(int indexRoom)
    {
        if (Index == indexRoom && isComplete == false)
        {
            TurnOnWall();

        }

    }
    public void RoomComplete(int indexRoom)
    {
        if (Index == indexRoom && isComplete == false)
        {
            isComplete = true;
            TurnOffWall();
        }
    }
    public void TurnOffWall()
    {
        WallObject.SetActive(false);
    }
    public void TurnOnWall()
    {
        WallObject.SetActive(true);
    }

}
