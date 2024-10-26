
using System.Collections.Generic;

using UnityEngine;


public class RoomGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public List<RoomPrefab> ListRoomData;
    public HashSet<Vector2Int> RoomWalk(RoomPrefab data, Vector2Int startPosition)
    {
        var _currenPosition = startPosition; // vị trí hiện tại  

        HashSet<Vector2Int> _floorPosition = new HashSet<Vector2Int>(); // tập hợp các ô thuộc floor 

        for (int i = 0; i < data.RoomSize; i++) // di chuyển ngẫu nhiên từ vị trí đầu tiên bằng số bước
        {
            var _path = Generation_algorithms.RoomGenerator(_currenPosition, data.RoomSize);
            _floorPosition.UnionWith(_path);
        }
        return _floorPosition;

    }
    public HashSet<Vector2Int> CreateRoom(List<Vector2Int> roomPositionStart)
    {
        HashSet<Vector2Int> _roomPositions = new HashSet<Vector2Int>();
        RoomManager.Instance.ListRoomSize.Clear();

        for (int i = 0; i < roomPositionStart.Count; i++)
        {

        }
        foreach (var position in roomPositionStart)
        {
            var _data = ListRoomData[Random.Range(0, ListRoomData.Count)];
            RoomManager.Instance.ListRoomSize.Add(_data.RoomSize);
            var _roomFloor = RoomWalk(_data, position);
            _roomPositions.UnionWith(_roomFloor);
        }
        return _roomPositions;
    }
}
