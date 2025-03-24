using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public List<GameObject> ListRoomObject;

    // Start is called before the first frame update
    void Start()
    {
        ObserverManager.AddListener("Map Generator Complete", NewMapTrigger);
        ObserverManager.AddListener<int>("Enter New Room", EnterNewRoomTrigger);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnDestroy()
    {
        ObserverManager.RemoveListener("Map Generator Complete", NewMapTrigger);
        ObserverManager.RemoveListener<int>("Enter New Room", EnterNewRoomTrigger);
    }
    public void NewMapTrigger()
    {
        ListRoomObject = ObjectPoolManager.Instance.ListObjectFromPool("Room");
        ListRoomObject[0].GetComponent<RoomObject>().isComplete = false;

    }
    public void EnterNewRoomTrigger(int roomIndex)
    {
        Debug.Log("Enter new room" + roomIndex);
        DungeonController.Instance.CurrentRoom = roomIndex;


    }


}
