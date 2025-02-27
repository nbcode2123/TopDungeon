using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UIElements;

public class RoomGenerator : MonoBehaviour
{

    public static Vector2Int[] Direction2D = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

    public List<Vector2Int> FloorGenerator(Vector2Int roomCenterPosition, int roomSize)
    {
        // tu vi tri trung tam di chuyen tren duoi bang 1/2 kich thuoc roi dua het vao 1 tempList

        List<Vector2Int> _floorPosition = new List<Vector2Int>
        {
            roomCenterPosition
        };
        int size = roomSize / 2;
        int x = roomCenterPosition.x;
        int y = roomCenterPosition.y;
        List<Vector2Int> _tempCenterRoom = new List<Vector2Int>
        {
            roomCenterPosition
        };
        Vector2Int _currentPosition, _nextPosition;
        _currentPosition = roomCenterPosition;
        for (int i = 0; i < size; i++)
        {
            _nextPosition = _currentPosition + Vector2Int.up;
            _floorPosition.Add(_nextPosition);
            _tempCenterRoom.Add(_nextPosition);
            _currentPosition = _nextPosition;
        }
        _currentPosition = roomCenterPosition;
        for (int i = 0; i < size; i++)
        {
            _nextPosition = _currentPosition + Vector2Int.down;
            _floorPosition.Add(_nextPosition);
            _tempCenterRoom.Add(_nextPosition);
            _currentPosition = _nextPosition;
        }
        // voi moi vi tri trong tempList do thi di chuyen sang trai phai 1/2 kich thuoc
        foreach (var position in _tempCenterRoom)
        {
            _currentPosition = position;
            for (int i = 0; i < size; i++)
            {
                _nextPosition = _currentPosition + Vector2Int.left;
                _floorPosition.Add(_nextPosition);
                _currentPosition = _nextPosition;
            }
            _currentPosition = position;
            for (int i = 0; i < size; i++)
            {
                _nextPosition = _currentPosition + Vector2Int.right;
                _floorPosition.Add(_nextPosition);
                _currentPosition = _nextPosition;
            }
        }

        return _floorPosition;

    }


}

