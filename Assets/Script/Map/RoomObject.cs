using System;
using System.Collections;
using System.Collections.Generic;
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
