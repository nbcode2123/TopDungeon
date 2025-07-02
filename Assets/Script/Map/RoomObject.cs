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
    public List<Vector2Int> ListWallPosition;
    public Vector2Int CenterPosition;


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
        ObserverManager.RemoveListener<int>("Room Complete", RoomComplete);


    }
    void OnEnable()
    {
        // ObserverManager.AddListener<int>("Enter New Room", ActiveRoom);
        // ObserverManager.AddListener<int>("Room Complete", RoomComplete);

    }
    void OnDestroy()
    {
        ObserverManager.RemoveListener<int>("Enter New Room", ActiveRoom);
        ObserverManager.RemoveListener<int>("Room Complete", RoomComplete);


    }
    public void ActiveRoom(int indexRoom)
    {
        if (Index == indexRoom && isComplete == false)
        {
            StartCoroutine(DelayActiveRoom());
        }

    }
    public IEnumerator DelayActiveRoom()
    {
        yield return new WaitForSeconds(0.2f);
        TurnOnWall();

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
        if (WallObject != null)
        {
            WallObject.SetActive(false);

        }
    }
    public void TurnOnWall()
    {
        if (WallObject != null)
        {
            WallObject.SetActive(true);

        }
    }

}
